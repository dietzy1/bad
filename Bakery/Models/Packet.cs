using SQLite;

namespace Bakery.Models
{
    public class Packet
    {
        public int PacketId { get; set; }
        public int TrackId { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;


    }
}