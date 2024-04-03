

namespace Bakery.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public int AmountOfGoods { get; set; }
        public DateTime TargetStartTime { get; set; }
        public DateTime TargetFinishTime { get; set; }
        public int? Delay { get; set; }
        public int BakingGoodId { get; set; }
        public required virtual BakingGood BakingGood { get; set; }
        public required virtual ICollection<Ingredient> Ingredients { get; set; }
        public required virtual ICollection<BatchIngredient> BatchIngredients { get; set; }


    }
}