namespace Bakery.Models;
public class Ingredient
{
    public int IngredientId { get; set; }
    public required string Stock { get; set; }
    public int Amount { get; set; }
    //public required virtual ICollection<Batch> Batches { get; set; }
    public required virtual ICollection<BatchIngredient> BatchIngredients { get; set; }
}