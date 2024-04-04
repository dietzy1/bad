using System.Text.Json.Serialization;
using Bakery.Models;

namespace Bakery.Dtos;

public class OrderDto : Dto
{
    public static OrderDto FromEntity(Order order)
    {
        return new OrderDto
        {
            OrderId = order.OrderId,
            DeliveryPlace = order.DeliveryPlace,
            DeliveryDate = order.DeliveryDate
        };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? OrderId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DeliveryPlace { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DeliveryDate { get; set; }
}

