using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class BakeryDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakingGoods",
                columns: table => new
                {
                    BakingGoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakingGoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantityOrdered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakingGoods", x => x.BakingGoodId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantityOrdered = table.Column<int>(type: "int", nullable: false),
                    TargetStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetFinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delay = table.Column<int>(type: "int", nullable: true),
                    BakingGoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_Batches_BakingGoods_BakingGoodId",
                        column: x => x.BakingGoodId,
                        principalTable: "BakingGoods",
                        principalColumn: "BakingGoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBakingGood",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BakingGoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBakingGood", x => new { x.OrderId, x.BakingGoodId });
                    table.ForeignKey(
                        name: "FK_OrderBakingGood_BakingGoods_BakingGoodId",
                        column: x => x.BakingGoodId,
                        principalTable: "BakingGoods",
                        principalColumn: "BakingGoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBakingGood_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packets",
                columns: table => new
                {
                    PacketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packets", x => x.PacketId);
                    table.ForeignKey(
                        name: "FK_Packets_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchIngredient",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchIngredient", x => new { x.BatchId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_BatchIngredient_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BakingGoods",
                columns: new[] { "BakingGoodId", "BakingGoodName", "TotalQuantityOrdered" },
                values: new object[,]
                {
                    { 1, "Cake", 10 },
                    { 2, "Cookie", 20 },
                    { 3, "Bread", 30 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name", "Stock" },
                values: new object[,]
                {
                    { 1, "Flour", 5000 },
                    { 2, "Sugar", 2000 },
                    { 3, "Butter", 500 },
                    { 4, "Egg", 250 },
                    { 5, "Milk", 50 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "DeliveryDate", "DeliveryPlace" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 4, 17, 57, 4, 281, DateTimeKind.Local).AddTicks(1595), "Storcenter Nord, Aarhus N, Denmark" },
                    { 2, new DateTime(2024, 4, 4, 19, 57, 4, 281, DateTimeKind.Local).AddTicks(1602), "Coop 365, Aarhus C, Denmark" },
                    { 3, new DateTime(2024, 4, 4, 21, 57, 4, 281, DateTimeKind.Local).AddTicks(1606), "Hos Perto Hansen, Aarhus V, Denmark" }
                });

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "BatchId", "BakingGoodId", "Delay", "TargetFinishTime", "TargetStartTime", "TotalQuantityOrdered" },
                values: new object[,]
                {
                    { 1, 1, 20, new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1443), new DateTime(2024, 4, 4, 9, 57, 4, 281, DateTimeKind.Local).AddTicks(1368), 10 },
                    { 2, 2, 40, new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1458), new DateTime(2024, 4, 4, 10, 57, 4, 281, DateTimeKind.Local).AddTicks(1454), 20 },
                    { 3, 3, 50, new DateTime(2024, 4, 4, 12, 57, 4, 281, DateTimeKind.Local).AddTicks(1467), new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1463), 30 },
                    { 4, 3, null, new DateTime(2024, 4, 4, 13, 57, 4, 281, DateTimeKind.Local).AddTicks(1476), new DateTime(2024, 4, 4, 12, 57, 4, 281, DateTimeKind.Local).AddTicks(1473), 40 }
                });

            migrationBuilder.InsertData(
                table: "OrderBakingGood",
                columns: new[] { "BakingGoodId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 10 },
                    { 2, 2, 20 },
                    { 3, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "Packets",
                columns: new[] { "PacketId", "OrderId", "TrackId" },
                values: new object[,]
                {
                    { 1, 1, 1234321 },
                    { 2, 1, 345313 },
                    { 3, 2, 16332 }
                });

            migrationBuilder.InsertData(
                table: "BatchIngredient",
                columns: new[] { "BatchId", "IngredientId", "IngredientAmount" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 1, 2, 50 },
                    { 1, 3, 20 },
                    { 1, 4, 10 },
                    { 2, 2, 10 },
                    { 2, 3, 10 },
                    { 2, 4, 5 },
                    { 3, 1, 5 },
                    { 3, 3, 10 },
                    { 3, 4, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BakingGoodId",
                table: "Batches",
                column: "BakingGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchIngredient_IngredientId",
                table: "BatchIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBakingGood_BakingGoodId",
                table: "OrderBakingGood",
                column: "BakingGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Packets_OrderId",
                table: "Packets",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchIngredient");

            migrationBuilder.DropTable(
                name: "OrderBakingGood");

            migrationBuilder.DropTable(
                name: "Packets");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BakingGoods");
        }
    }
}
