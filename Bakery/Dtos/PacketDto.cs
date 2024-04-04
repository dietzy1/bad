using System.Text.Json.Serialization;
using Bakery.Models;

namespace Bakery.Dtos;

public class PacketDto : Dto
{
    public static PacketDto FromEntity(Packet packet)
    {
        return new PacketDto
        {
            //PacketId = packet.PacketId,
            //OrderId = packet.OrderId,
            TrackId = packet.TrackId
        };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PacketId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? OrderId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TrackId { get; set; }
}

