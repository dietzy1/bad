

namespace Bakery.Models
{
    public class Allergen
    {
        public int AllergenId { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Ingredient> Ingredients { get; set; } = null!;

    }
}