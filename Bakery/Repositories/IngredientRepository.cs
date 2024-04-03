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
            .Where(i => i.BatchIngredients.Any(bi => bi.BatchId == batchId))
            .ToArrayAsync();
    }

    public async Task<Ingredient?> GetIngredientById(int id)
    {
        return await Context.Ingredients.FindAsync(id);
    }

    public async Task AddIngredient(Ingredient ingredient)
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
