namespace Bakery.Dtos;

public class CreateIngredientDto : Dto
{
    public required string Name { get; set; }
    public required int Quantity { get; set; }
}
