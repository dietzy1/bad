using Microsoft.EntityFrameworkCore;

namespace Bakery.Models;

public class BakeryContext : DbContext
{
    public BakeryContext(DbContextOptions<BakeryContext> options)
        : base(options)
    {
    }

    public DbSet<Ingredient> Ingredients { get; set; } = null!;
}