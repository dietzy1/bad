

namespace Bakery.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string DeliveryPlace { get; set; }
        public string? DeliveryDate { get; set; } //This was migrated in migration 2
        //public virtual ICollection<BakingGood> BakingGoods { get; set; } = null!;
        public virtual ICollection<OrderBakingGood> OrderBakingGoods { get; set; } = null!;
        public virtual ICollection<Packet> Packets { get; set; } = null!;

        public string? DeliveryCoordinates { get; set; } = null!; //This was migrated in migration 3
    }
}
