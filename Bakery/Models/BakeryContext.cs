using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { IngredientId = 1, Name = "Flour", Stock = 5000 },
            new Ingredient { IngredientId = 2, Name = "Sugar", Stock = 2000 },
            new Ingredient { IngredientId = 3, Name = "Butter", Stock = 500 },
            new Ingredient { IngredientId = 4, Name = "Egg", Stock = 250 },
            new Ingredient { IngredientId = 5, Name = "Milk", Stock = 50 }
        );

        modelBuilder.Entity<Batch>().HasData(
            new Batch
            {
                BatchId = 1,
                BakingGoodId = 1,
                TotalQuantityOrdered = 10,
                TargetStartTime = DateTime.Now.ToString(),
                TargetFinishTime = DateTime.Now.AddHours(2).ToString(),
                Delay = 20
            },
            new Batch
            {
                BatchId = 2,
                BakingGoodId = 2,
                TotalQuantityOrdered = 20,
                TargetStartTime = DateTime.Now.AddHours(1).ToString(),
                TargetFinishTime = DateTime.Now.AddHours(2).ToString(),
                Delay = 40
            },
            new Batch
            {
                BatchId = 3,
                BakingGoodId = 3,
                TotalQuantityOrdered = 30,
                TargetStartTime = DateTime.Now.AddHours(2).ToString(),
                TargetFinishTime = DateTime.Now.AddHours(3).ToString(),
                Delay = 50
            },
            new Batch
            {
                BatchId = 4,
                BakingGoodId = 3,
                TotalQuantityOrdered = 40,
                TargetStartTime = DateTime.Now.AddHours(3).ToString(),
                TargetFinishTime = DateTime.Now.AddHours(4).ToString(),
                Delay = null
            }
        );


        modelBuilder.Entity<BakingGood>().HasData(
            new BakingGood
            {
                BakingGoodId = 1,
                BakingGoodName = "Cake",
                TotalQuantityOrdered = 10
            },
            new BakingGood
            {
                BakingGoodId = 2,
                BakingGoodName = "Cookie",
                TotalQuantityOrdered = 20
            },
            new BakingGood
            {
                BakingGoodId = 3,
                BakingGoodName = "Bread",
                TotalQuantityOrdered = 30
            }
        );


        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1,
                DeliveryDate = DateTime.Now.AddHours(8).ToString(),
                DeliveryPlace = "Storcenter Nord, Aarhus N, Denmark",
            },
            new Order
            {
                OrderId = 2,
                DeliveryDate = DateTime.Now.AddHours(10).ToString(),
                DeliveryPlace = "Coop 365, Aarhus C, Denmark",
            },
            new Order
            {
                OrderId = 3,
                DeliveryDate = DateTime.Now.AddHours(12).ToString(),
                DeliveryPlace = "Hos Perto Hansen, Aarhus V, Denmark",
            }

        );

        modelBuilder.Entity<Packet>().HasData(
            new Packet
            {
                PacketId = 1,
                OrderId = 1,
                TrackId = 1234321,
            },
            new Packet
            {
                PacketId = 2,
                OrderId = 1,
                TrackId = 345313,
            },
            new Packet
            {
                PacketId = 3,
                OrderId = 2,
                TrackId = 16332,
            }
        );



        modelBuilder.Entity<OrderBakingGood>().HasData(
            new OrderBakingGood
            {
                OrderId = 1,
                BakingGoodId = 1,
                Quantity = 10
            },

            new OrderBakingGood
            {
                OrderId = 2,
                BakingGoodId = 2,
                Quantity = 20
            },

            new OrderBakingGood
            {
                OrderId = 3,
                BakingGoodId = 3,
                Quantity = 30
            }
        );



        modelBuilder.Entity<BatchIngredient>().HasData(
            new BatchIngredient
            {
                BatchId = 1,
                IngredientId = 1,
                IngredientAmount = 100
            },
            new BatchIngredient
            {
                BatchId = 1,
                IngredientId = 2,
                IngredientAmount = 50
            },
            new BatchIngredient
            {
                BatchId = 1,
                IngredientId = 3,
                IngredientAmount = 20
            },
            new BatchIngredient
            {
                BatchId = 1,
                IngredientId = 4,
                IngredientAmount = 10
            },
            new BatchIngredient
            {
                BatchId = 2,
                IngredientId = 2,
                IngredientAmount = 10
            },
            new BatchIngredient
            {
                BatchId = 2,
                IngredientId = 3,
                IngredientAmount = 10
            },
            new BatchIngredient
            {
                BatchId = 2,
                IngredientId = 4,
                IngredientAmount = 5
            },
            new BatchIngredient
            {
                BatchId = 3,
                IngredientId = 1,
                IngredientAmount = 5
            },
            new BatchIngredient
            {
                BatchId = 3,
                IngredientId = 3,
                IngredientAmount = 10
            },
            new BatchIngredient
            {
                BatchId = 3,
                IngredientId = 4,
                IngredientAmount = 50
            }
        );

    }
}
