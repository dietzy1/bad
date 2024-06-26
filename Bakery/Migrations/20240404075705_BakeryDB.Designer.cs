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
    [Migration("20240404075705_BakeryDB")]
    partial class BakeryDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<DateTime>("TargetFinishTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TargetStartTime")
                        .HasColumnType("datetime2");

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
                            TargetFinishTime = new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1443),
                            TargetStartTime = new DateTime(2024, 4, 4, 9, 57, 4, 281, DateTimeKind.Local).AddTicks(1368),
                            TotalQuantityOrdered = 10
                        },
                        new
                        {
                            BatchId = 2,
                            BakingGoodId = 2,
                            Delay = 40,
                            TargetFinishTime = new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1458),
                            TargetStartTime = new DateTime(2024, 4, 4, 10, 57, 4, 281, DateTimeKind.Local).AddTicks(1454),
                            TotalQuantityOrdered = 20
                        },
                        new
                        {
                            BatchId = 3,
                            BakingGoodId = 3,
                            Delay = 50,
                            TargetFinishTime = new DateTime(2024, 4, 4, 12, 57, 4, 281, DateTimeKind.Local).AddTicks(1467),
                            TargetStartTime = new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1463),
                            TotalQuantityOrdered = 30
                        },
                        new
                        {
                            BatchId = 4,
                            BakingGoodId = 3,
                            TargetFinishTime = new DateTime(2024, 4, 4, 13, 57, 4, 281, DateTimeKind.Local).AddTicks(1476),
                            TargetStartTime = new DateTime(2024, 4, 4, 12, 57, 4, 281, DateTimeKind.Local).AddTicks(1473),
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

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            DeliveryDate = new DateTime(2024, 4, 4, 17, 57, 4, 281, DateTimeKind.Local).AddTicks(1595),
                            DeliveryPlace = "Storcenter Nord, Aarhus N, Denmark"
                        },
                        new
                        {
                            OrderId = 2,
                            DeliveryDate = new DateTime(2024, 4, 4, 19, 57, 4, 281, DateTimeKind.Local).AddTicks(1602),
                            DeliveryPlace = "Coop 365, Aarhus C, Denmark"
                        },
                        new
                        {
                            OrderId = 3,
                            DeliveryDate = new DateTime(2024, 4, 4, 21, 57, 4, 281, DateTimeKind.Local).AddTicks(1606),
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
