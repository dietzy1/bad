namespace Bakery.Repositories;

using Microsoft.EntityFrameworkCore;
using Bakery.Models;

public class IngredientRepository : Repository
{
    public IngredientRepository(BakeryContext context) : base(context) { }

    public async Task<Ingredient[]> ListIngredients()
    {
        return await Context.Ingredients.ToArrayAsync();
    }
    
    public async Task<Ingredient[]> ListIngredientsInBatch(int batchId)
    {
        return await Context.Ingredients
            .Include(i => i.Allergens)
            .Where(i => i.BatchIngredients.Any(bi => bi.BatchId == batchId))
            .ToArrayAsync();
    }

    public async Task<Allergen[]> ListAllergensOfIngredient(int ingredientId)
    {
        return await Context.Allergens
            .Where(a => a.Ingredients.Any(i => i.IngredientId == ingredientId))
            .ToArrayAsync();
    }

    public async Task<Ingredient?> GetIngredientById(int id)
    {
        return await Context.Ingredients.FindAsync(id);
    }

    public async Task CreateIngredient(Ingredient ingredient)
    {
        await Context.Ingredients.AddAsync(ingredient);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateIngredient(Ingredient ingredient)
    {
        Context.Ingredients.Update(ingredient);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteIngredient(Ingredient ingredient)
    {
        Context.Ingredients.Remove(ingredient);
        await Context.SaveChangesAsync();
    }
}
