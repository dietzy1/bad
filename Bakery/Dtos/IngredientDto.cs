using System.Text.Json.Serialization;
using Bakery.Models;

namespace Bakery.Dtos;

public class IngredientDto : Dto
{
    public static IngredientDto FromEntity(Ingredient ingredient)
    {
        return new IngredientDto
        {
            IngredientId = ingredient.IngredientId,
            Stock = ingredient.Stock,
            Name = ingredient.Name
        };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? IngredientId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Stock { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}
