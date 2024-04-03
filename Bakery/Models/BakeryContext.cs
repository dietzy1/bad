
using Microsoft.EntityFrameworkCore;
using System;

namespace Bakery.Models;

public class BakeryContext : DbContext
{
    public BakeryContext(DbContextOptions<BakeryContext> options)
        : base(options)
    {
    }

    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Packet> Packets { get; set; } = null!;
    public DbSet<BakingGood> BakingGoods { get; set; } = null!;
    public DbSet<Batch> Batches { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderBakingGood> OrderBakingGoods { get; set; } = null!;

    public DbSet<BatchIngredient> BatchIngredients { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderBakingGood>().ToTable("OrderBakingGood").HasKey(e => new { e.OrderId, e.BakingGoodId });

        modelBuilder.Entity<BatchIngredient>().ToTable("BatchIngredient").HasKey(e => new { e.BatchId, e.IngredientId });

    }
}