namespace Bakery.Models

{
    public class BakingGood
    {
        public int BakingGoodId { get; set; }
        public required string BakingGoodName { get; set; }
        public int TotalQuantity { get; set; }
        public required virtual ICollection<OrderBakingGood> OrderBakingGoods { get; set; }
        public required virtual ICollection<Batch> Batches { get; set; }

    }
}