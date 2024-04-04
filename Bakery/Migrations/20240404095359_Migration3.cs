using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 1:53:59 PM", "4/4/2024 11:53:59 AM" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 1:53:59 PM", "4/4/2024 12:53:59 PM" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 2:53:59 PM", "4/4/2024 1:53:59 PM" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 3:53:59 PM", "4/4/2024 2:53:59 PM" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: "4/4/2024 7:53:59 PM");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DeliveryDate",
                value: "4/4/2024 9:53:59 PM");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DeliveryDate",
                value: "4/4/2024 11:53:59 PM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 1:46:53 PM", "4/4/2024 11:46:53 AM" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 1:46:53 PM", "4/4/2024 12:46:53 PM" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 2:46:53 PM", "4/4/2024 1:46:53 PM" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "4/4/2024 3:46:53 PM", "4/4/2024 2:46:53 PM" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: "4/4/2024 7:46:53 PM");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DeliveryDate",
                value: "4/4/2024 9:46:53 PM");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "DeliveryDate",
                value: "4/4/2024 11:46:53 PM");
        }
    }
}
