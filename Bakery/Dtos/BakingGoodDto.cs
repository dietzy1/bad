using System.Text.Json.Serialization;
using Bakery.Models;

namespace Bakery.Dtos;

public class BakingGoodDto : Dto
{
    public static BakingGoodDto FromEntity(BakingGood bakingGood)
    {
        return new BakingGoodDto
        {
            BakingGoodId = bakingGood.BakingGoodId,
            BakingGoodName = bakingGood.BakingGoodName,
            TotalQuantityOrdered = bakingGood.TotalQuantityOrdered
        };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BakingGoodId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BakingGoodName { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TotalQuantityOrdered { get; set; }
}

