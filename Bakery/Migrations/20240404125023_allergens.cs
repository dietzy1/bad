using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class allergens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAllergen_Allergen_AllergenId",
                table: "IngredientAllergen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergen",
                table: "Allergen");

            migrationBuilder.RenameTable(
                name: "Allergen",
                newName: "Allergens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergens",
                table: "Allergens",
                column: "AllergenId");

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04042024 1650", "04042024 1450" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04042024 1650", "04042024 1550" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04042024 1750", "04042024 1650" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04042024 1850", "04042024 1750" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: "4/4/2024 10:50:23 PM");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DeliveryDate",
                value: "4/5/2024 12:50:23 AM");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DeliveryDate",
                value: "4/5/2024 2:50:23 AM");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAllergen_Allergens_AllergenId",
                table: "IngredientAllergen",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "AllergenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAllergen_Allergens_AllergenId",
                table: "IngredientAllergen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergens",
                table: "Allergens");

            migrationBuilder.RenameTable(
                name: "Allergens",
                newName: "Allergen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergen",
                table: "Allergen",
                column: "AllergenId");

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 15.08.39", "04/04/2024 13.08.39" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 15.08.39", "04/04/2024 14.08.39" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 16.08.39", "04/04/2024 15.08.39" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 17.08.39", "04/04/2024 16.08.39" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: "04/04/2024 21.08.39");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DeliveryDate",
                value: "04/04/2024 23.08.39");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DeliveryDate",
                value: "05/04/2024 01.08.39");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAllergen_Allergen_AllergenId",
                table: "IngredientAllergen",
                column: "AllergenId",
                principalTable: "Allergen",
                principalColumn: "AllergenId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
