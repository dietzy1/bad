



namespace Bakery.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string DeliveryPlace { get; set; }
        public DateTime DeliveryDate { get; set; }
        public required virtual ICollection<BakingGood> BakingGoods { get; set; }
        public required virtual ICollection<OrderBakingGood> OrderBakingGoods { get; set; }
        public required virtual ICollection<Packet> Packets { get; set; }
    }
}