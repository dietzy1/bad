using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bakery.Models;

public class BakeryContext : IdentityDbContext<ApiUser>
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
    public DbSet<Allergen> Allergens { get; set; } = null!;

    public DbSet<OrderBakingGood> OrderBakingGoods { get; set; } = null!;

    public DbSet<BatchIngredient> BatchIngredients { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This is needed to make the identity work for some reason :)
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderBakingGood>().ToTable("OrderBakingGood").HasKey(e => new { e.OrderId, e.BakingGoodId });

        modelBuilder.Entity<BatchIngredient>().ToTable("BatchIngredient").HasKey(e => new { e.BatchId, e.IngredientId });

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { IngredientId = 1, Name = "Flour", Stock = 5000 },
            new Ingredient { IngredientId = 2, Name = "Sugar", Stock = 2000 },
            new Ingredient { IngredientId = 3, Name = "Butter", Stock = 500 },
            new Ingredient { IngredientId = 4, Name = "Egg", Stock = 250 },
            new Ingredient { IngredientId = 5, Name = "Milk", Stock = 50 }
        );
        modelBuilder.Entity<Ingredient>()
            .HasMany(i => i.Allergens)
                .WithMany(a => a.Ingredients)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientAllergen",
                    r => r.HasOne<Allergen>().WithMany().HasForeignKey("AllergenId"),
                    l => l.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientId"),
                    je =>
                    {
                        je.HasKey("IngredientId", "AllergenId");
                        je.HasData(
                            new { IngredientId = 1, AllergenId = 1 },
                            new { IngredientId = 3, AllergenId = 2 },
                            new { IngredientId = 4, AllergenId = 3 }
                        );
                    });

        modelBuilder.Entity<Batch>().HasData(
            new Batch
            {
                BatchId = 1,
                BakingGoodId = 1,
                TotalQuantityOrdered = 10,
                TargetStartTime = DateTime.Now.ToString("ddMMyyyy HHmm"),
                TargetFinishTime = DateTime.Now.AddHours(2).ToString("ddMMyyyy HHmm"),
                Delay = 20
            },
            new Batch
            {
                BatchId = 2,
                BakingGoodId = 2,
                TotalQuantityOrdered = 20,
                TargetStartTime = DateTime.Now.AddHours(1).ToString("ddMMyyyy HHmm"),
                TargetFinishTime = DateTime.Now.AddHours(2).ToString("ddMMyyyy HHmm"),
                Delay = 40
            },
            new Batch
            {
                BatchId = 3,
                BakingGoodId = 3,
                TotalQuantityOrdered = 30,
                TargetStartTime = DateTime.Now.AddHours(2).ToString("ddMMyyyy HHmm"),
                TargetFinishTime = DateTime.Now.AddHours(3).ToString("ddMMyyyy HHmm"),
                Delay = 50
            },
            new Batch
            {
                BatchId = 4,
                BakingGoodId = 3,
                TotalQuantityOrdered = 40,
                TargetStartTime = DateTime.Now.AddHours(3).ToString("ddMMyyyy HHmm"),
                TargetFinishTime = DateTime.Now.AddHours(4).ToString("ddMMyyyy HHmm"),
                Delay = null,

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
                DeliveryCoordinates = "56.1833, 10.2039",
            },
            new Order
            {
                OrderId = 2,
                DeliveryDate = DateTime.Now.AddHours(10).ToString(),
                DeliveryPlace = "Coop 365, Aarhus C, Denmark",
                DeliveryCoordinates = "49.1629, 34.2039",
            },
            new Order
            {
                OrderId = 3,
                DeliveryDate = DateTime.Now.AddHours(12).ToString(),
                DeliveryPlace = "Hos Perto Hansen, Aarhus V, Denmark",
                DeliveryCoordinates = "60.1833, 13.2039",
            }
        );

        modelBuilder.Entity<Allergen>().HasData(
            new Allergen
            {
                AllergenId = 1,
                Name = "Gluten"
            },
            new Allergen
            {
                AllergenId = 2,
                Name = "Lactose"
            },
            new Allergen
            {
                AllergenId = 3,
                Name = "Nuts"
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
