

namespace Bakery.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string DeliveryPlace { get; set; }
        public DateTime DeliveryDate { get; set; }
        //public virtual ICollection<BakingGood> BakingGoods { get; set; } = null!;
        public virtual ICollection<OrderBakingGood> OrderBakingGoods { get; set; } = null!;
        public virtual ICollection<Packet> Packets { get; set; } = null!;
    }
}