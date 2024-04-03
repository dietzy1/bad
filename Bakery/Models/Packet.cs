
using SQLite;

namespace Bakery.Models
{
    public class Packet
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int TrackId { get; set; }
    }
}