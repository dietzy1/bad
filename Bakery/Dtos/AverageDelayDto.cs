using System.Text.Json.Serialization;

namespace Bakery.Dtos;

public class AverageDelayDto : Dto
{
    public static AverageDelayDto FromDelay(double delay)
    {
        return new AverageDelayDto
        {
            AverageDelay = delay,
        };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AverageDelay { get; set; }
}


