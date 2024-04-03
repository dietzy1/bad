

namespace Bakery.Models

{
    public class BakingGood
    {
        public int BakingGoodId { get; set; }
        public required string BakingGoodName { get; set; }
        public int TotalQuantityOrdered { get; set; }
        public virtual ICollection<OrderBakingGood> OrderBakingGoods { get; set; } = null!;
        public virtual ICollection<Batch> Batches { get; set; } = null!;

    }
}