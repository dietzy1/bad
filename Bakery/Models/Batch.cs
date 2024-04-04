

namespace Bakery.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public int TotalQuantityOrdered { get; set; }
        public string? TargetStartTime { get; set; }//This was migrated in migration 2
        public string? TargetFinishTime { get; set; }//This was migrated in migration 2
        public int? Delay { get; set; }
        public int BakingGoodId { get; set; }
        public virtual BakingGood BakingGood { get; set; } = null!;
        //public virtual ICollection<Ingredient> Ingredients { get; set; } = null!;
        public virtual ICollection<BatchIngredient> BatchIngredients { get; set; } = null!;


    }
}