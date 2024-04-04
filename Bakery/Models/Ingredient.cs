namespace Bakery.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public int Stock { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<BatchIngredient> BatchIngredients { get; set; } = null!;
    public virtual ICollection<Allergen> Allergens { get; set; } = null!; //This field was added in migration 1
}