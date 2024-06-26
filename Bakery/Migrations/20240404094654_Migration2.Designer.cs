﻿// <auto-generated />
using System;
using Bakery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bakery.Migrations
{
    [DbContext(typeof(BakeryContext))]
    [Migration("20240404094654_Migration2")]
    partial class Migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllergenIngredient", b =>
                {
                    b.Property<int>("AllergensAllergenId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsIngredientId")
                        .HasColumnType("int");

                    b.HasKey("AllergensAllergenId", "IngredientsIngredientId");

                    b.HasIndex("IngredientsIngredientId");

                    b.ToTable("AllergenIngredient");
                });

            modelBuilder.Entity("Bakery.Models.Allergen", b =>
                {
                    b.Property<int>("AllergenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergenId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergenId");

                    b.ToTable("Allergen");
                });

            modelBuilder.Entity("Bakery.Models.BakingGood", b =>
                {
                    b.Property<int>("BakingGoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BakingGoodId"));

                    b.Property<string>("BakingGoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalQuantityOrdered")
                        .HasColumnType("int");

                    b.HasKey("BakingGoodId");

                    b.ToTable("BakingGoods");

                    b.HasData(
                        new
                        {
                            BakingGoodId = 1,
                            BakingGoodName = "Cake",
                            TotalQuantityOrdered = 10
                        },
                        new
                        {
                            BakingGoodId = 2,
                            BakingGoodName = "Cookie",
                            TotalQuantityOrdered = 20
                        },
                        new
                        {
                            BakingGoodId = 3,
                            BakingGoodName = "Bread",
                            TotalQuantityOrdered = 30
                        });
                });

            modelBuilder.Entity("Bakery.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchId"));

                    b.Property<int>("BakingGoodId")
                        .HasColumnType("int");

                    b.Property<int?>("Delay")
                        .HasColumnType("int");

                    b.Property<string>("TargetFinishTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalQuantityOrdered")
                        .HasColumnType("int");

                    b.HasKey("BatchId");

                    b.HasIndex("BakingGoodId");

                    b.ToTable("Batches");

                    b.HasData(
                        new
                        {
                            BatchId = 1,
                            BakingGoodId = 1,
                            Delay = 20,
                            TargetFinishTime = "4/4/2024 1:46:53 PM",
                            TargetStartTime = "4/4/2024 11:46:53 AM",
                            TotalQuantityOrdered = 10
                        },
                        new
                        {
                            BatchId = 2,
                            BakingGoodId = 2,
                            Delay = 40,
                            TargetFinishTime = "4/4/2024 1:46:53 PM",
                            TargetStartTime = "4/4/2024 12:46:53 PM",
                            TotalQuantityOrdered = 20
                        },
                        new
                        {
                            BatchId = 3,
                            BakingGoodId = 3,
                            Delay = 50,
                            TargetFinishTime = "4/4/2024 2:46:53 PM",
                            TargetStartTime = "4/4/2024 1:46:53 PM",
                            TotalQuantityOrdered = 30
                        },
                        new
                        {
                            BatchId = 4,
                            BakingGoodId = 3,
                            TargetFinishTime = "4/4/2024 3:46:53 PM",
                            TargetStartTime = "4/4/2024 2:46:53 PM",
                            TotalQuantityOrdered = 40
                        });
                });

            modelBuilder.Entity("Bakery.Models.BatchIngredient", b =>
                {
                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientAmount")
                        .HasColumnType("int");

                    b.HasKey("BatchId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("BatchIngredient", (string)null);

                    b.HasData(
                        new
                        {
                            BatchId = 1,
                            IngredientId = 1,
                            IngredientAmount = 100
                        },
                        new
                        {
                            BatchId = 1,
                            IngredientId = 2,
                            IngredientAmount = 50
                        },
                        new
                        {
                            BatchId = 1,
                            IngredientId = 3,
                            IngredientAmount = 20
                        },
                        new
                        {
                            BatchId = 1,
                            IngredientId = 4,
                            IngredientAmount = 10
                        },
                        new
                        {
                            BatchId = 2,
                            IngredientId = 2,
                            IngredientAmount = 10
                        },
                        new
                        {
                            BatchId = 2,
                            IngredientId = 3,
                            IngredientAmount = 10
                        },
                        new
                        {
                            BatchId = 2,
                            IngredientId = 4,
                            IngredientAmount = 5
                        },
                        new
                        {
                            BatchId = 3,
                            IngredientId = 1,
                            IngredientAmount = 5
                        },
                        new
                        {
                            BatchId = 3,
                            IngredientId = 3,
                            IngredientAmount = 10
                        },
                        new
                        {
                            BatchId = 3,
                            IngredientId = 4,
                            IngredientAmount = 50
                        });
                });

            modelBuilder.Entity("Bakery.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "Flour",
                            Stock = 5000
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "Sugar",
                            Stock = 2000
                        },
                        new
                        {
                            IngredientId = 3,
                            Name = "Butter",
                            Stock = 500
                        },
                        new
                        {
                            IngredientId = 4,
                            Name = "Egg",
                            Stock = 250
                        },
                        new
                        {
                            IngredientId = 5,
                            Name = "Milk",
                            Stock = 50
                        });
                });

            modelBuilder.Entity("Bakery.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("DeliveryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            DeliveryDate = "4/4/2024 7:46:53 PM",
                            DeliveryPlace = "Storcenter Nord, Aarhus N, Denmark"
                        },
                        new
                        {
                            OrderId = 2,
                            DeliveryDate = "4/4/2024 9:46:53 PM",
                            DeliveryPlace = "Coop 365, Aarhus C, Denmark"
                        },
                        new
                        {
                            OrderId = 3,
                            DeliveryDate = "4/4/2024 11:46:53 PM",
                            DeliveryPlace = "Hos Perto Hansen, Aarhus V, Denmark"
                        });
                });

            modelBuilder.Entity("Bakery.Models.OrderBakingGood", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BakingGoodId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "BakingGoodId");

                    b.HasIndex("BakingGoodId");

                    b.ToTable("OrderBakingGood", (string)null);

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            BakingGoodId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            OrderId = 2,
                            BakingGoodId = 2,
                            Quantity = 20
                        },
                        new
                        {
                            OrderId = 3,
                            BakingGoodId = 3,
                            Quantity = 30
                        });
                });

            modelBuilder.Entity("Bakery.Models.Packet", b =>
                {
                    b.Property<int>("PacketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacketId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("PacketId");

                    b.HasIndex("OrderId");

                    b.ToTable("Packets");

                    b.HasData(
                        new
                        {
                            PacketId = 1,
                            OrderId = 1,
                            TrackId = 1234321
                        },
                        new
                        {
                            PacketId = 2,
                            OrderId = 1,
                            TrackId = 345313
                        },
                        new
                        {
                            PacketId = 3,
                            OrderId = 2,
                            TrackId = 16332
                        });
                });

            modelBuilder.Entity("AllergenIngredient", b =>
                {
                    b.HasOne("Bakery.Models.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergensAllergenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bakery.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bakery.Models.Batch", b =>
                {
                    b.HasOne("Bakery.Models.BakingGood", "BakingGood")
                        .WithMany("Batches")
                        .HasForeignKey("BakingGoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingGood");
                });

            modelBuilder.Entity("Bakery.Models.BatchIngredient", b =>
                {
                    b.HasOne("Bakery.Models.Batch", "Batch")
                        .WithMany("BatchIngredients")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bakery.Models.Ingredient", "Ingredient")
                        .WithMany("BatchIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Bakery.Models.OrderBakingGood", b =>
                {
                    b.HasOne("Bakery.Models.BakingGood", "BakingGood")
                        .WithMany("OrderBakingGoods")
                        .HasForeignKey("BakingGoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bakery.Models.Order", "Order")
                        .WithMany("OrderBakingGoods")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingGood");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Bakery.Models.Packet", b =>
                {
                    b.HasOne("Bakery.Models.Order", "Order")
                        .WithMany("Packets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Bakery.Models.BakingGood", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("OrderBakingGoods");
                });

            modelBuilder.Entity("Bakery.Models.Batch", b =>
                {
                    b.Navigation("BatchIngredients");
                });

            modelBuilder.Entity("Bakery.Models.Ingredient", b =>
                {
                    b.Navigation("BatchIngredients");
                });

            modelBuilder.Entity("Bakery.Models.Order", b =>
                {
                    b.Navigation("OrderBakingGoods");

                    b.Navigation("Packets");
                });
#pragma warning restore 612, 618
        }
    }
}
