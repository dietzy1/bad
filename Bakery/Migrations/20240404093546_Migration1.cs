using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergen",
                columns: table => new
                {
                    AllergenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergen", x => x.AllergenId);
                });

            migrationBuilder.CreateTable(
                name: "AllergenIngredient",
                columns: table => new
                {
                    AllergensAllergenId = table.Column<int>(type: "int", nullable: false),
                    IngredientsIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenIngredient", x => new { x.AllergensAllergenId, x.IngredientsIngredientId });
                    table.ForeignKey(
                        name: "FK_AllergenIngredient_Allergen_AllergensAllergenId",
                        column: x => x.AllergensAllergenId,
                        principalTable: "Allergen",
                        principalColumn: "AllergenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenIngredient_Ingredients_IngredientsIngredientId",
                        column: x => x.IngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 35, 45, 871, DateTimeKind.Local).AddTicks(1460), new DateTime(2024, 4, 4, 11, 35, 45, 871, DateTimeKind.Local).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 35, 45, 871, DateTimeKind.Local).AddTicks(1480), new DateTime(2024, 4, 4, 12, 35, 45, 871, DateTimeKind.Local).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 14, 35, 45, 871, DateTimeKind.Local).AddTicks(1480), new DateTime(2024, 4, 4, 13, 35, 45, 871, DateTimeKind.Local).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 15, 35, 45, 871, DateTimeKind.Local).AddTicks(1480), new DateTime(2024, 4, 4, 14, 35, 45, 871, DateTimeKind.Local).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: new DateTime(2024, 4, 4, 19, 35, 45, 871, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DeliveryDate",
                value: new DateTime(2024, 4, 4, 21, 35, 45, 871, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DeliveryDate",
                value: new DateTime(2024, 4, 4, 23, 35, 45, 871, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.CreateIndex(
                name: "IX_AllergenIngredient_IngredientsIngredientId",
                table: "AllergenIngredient",
                column: "IngredientsIngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenIngredient");

            migrationBuilder.DropTable(
                name: "Allergen");

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1443), new DateTime(2024, 4, 4, 9, 57, 4, 281, DateTimeKind.Local).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1458), new DateTime(2024, 4, 4, 10, 57, 4, 281, DateTimeKind.Local).AddTicks(1454) });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 57, 4, 281, DateTimeKind.Local).AddTicks(1467), new DateTime(2024, 4, 4, 11, 57, 4, 281, DateTimeKind.Local).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 57, 4, 281, DateTimeKind.Local).AddTicks(1476), new DateTime(2024, 4, 4, 12, 57, 4, 281, DateTimeKind.Local).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: new DateTime(2024, 4, 4, 17, 57, 4, 281, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DeliveryDate",
                value: new DateTime(2024, 4, 4, 19, 57, 4, 281, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DeliveryDate",
                value: new DateTime(2024, 4, 4, 21, 57, 4, 281, DateTimeKind.Local).AddTicks(1606));
        }
    }
}
