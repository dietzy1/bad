

namespace Bakery.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public int TotalQuantityOrdered { get; set; }
        public DateTime TargetStartTime { get; set; }
        public DateTime TargetFinishTime { get; set; }
        public int? Delay { get; set; }
        public int BakingGoodId { get; set; }
        public virtual BakingGood BakingGood { get; set; } = null!;
        public virtual ICollection<Ingredient> Ingredients { get; set; } = null!;
        public virtual ICollection<BatchIngredient> BatchIngredients { get; set; } = null!;


    }
}