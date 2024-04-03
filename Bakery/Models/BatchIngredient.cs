


using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
    public class BatchIngredient
    {
        public int BatchId { get; set; }
        public int IngredientId { get; set; }
        public int IngredientAmount { get; set; }
        public Batch Batch { get; set; } = null!;
        public Ingredient Ingredient { get; set; } = null!;
    }
}