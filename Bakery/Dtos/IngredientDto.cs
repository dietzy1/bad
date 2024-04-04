using System.Text.Json.Serialization;
using Bakery.Models;

namespace Bakery.Dtos;

public class IngredientDto : Dto
{
    public static IngredientDto FromEntity(Ingredient ingredient)
    {
        var dto = new IngredientDto
        {
            IngredientId = ingredient.IngredientId,
            Stock = ingredient.Stock,
            Name = ingredient.Name
        };
        if (ingredient.Allergens != null)
        {
            dto.Allergens = new List<AllergenDto>();
            foreach (var allergen in ingredient.Allergens)
            {
                dto.Allergens.Add(AllergenDto.FromEntity(allergen));
            }
        }

        return dto;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? IngredientId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Stock { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<AllergenDto>? Allergens { get; set; }
}
