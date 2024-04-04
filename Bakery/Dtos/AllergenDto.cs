using System.Text.Json.Serialization;
using Bakery.Models;

namespace Bakery.Dtos;

public class AllergenDto : Dto
{
    public static AllergenDto FromEntity(Allergen allergen)
    {
        return new AllergenDto
        {
            AllergenId = allergen.AllergenId,
            Name = allergen.Name,
        };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? AllergenId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}

