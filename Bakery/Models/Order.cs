



namespace Bakery.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public required virtual ICollection<BakingGood> OrderBakingGoods { get; set; }
    }
}