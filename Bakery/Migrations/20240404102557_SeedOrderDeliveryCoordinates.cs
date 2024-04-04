using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderDeliveryCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 14.25.57", "04/04/2024 12.25.57" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 14.25.57", "04/04/2024 13.25.57" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 15.25.57", "04/04/2024 14.25.57" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 16.25.57", "04/04/2024 15.25.57" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: "04/04/2024 20.25.57");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "DeliveryCoordinates", "DeliveryDate" },
                values: new object[] { "49.1629, 34.2039", "04/04/2024 22.25.57" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "DeliveryCoordinates", "DeliveryDate" },
                values: new object[] { "60.1833, 13.2039", "05/04/2024 00.25.57" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 14.24.02", "04/04/2024 12.24.02" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 14.24.02", "04/04/2024 13.24.02" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 3,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 15.24.02", "04/04/2024 14.24.02" });

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 4,
                columns: new[] { "TargetFinishTime", "TargetStartTime" },
                values: new object[] { "04/04/2024 16.24.02", "04/04/2024 15.24.02" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DeliveryDate",
                value: "04/04/2024 20.24.02");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "DeliveryCoordinates", "DeliveryDate" },
                values: new object[] { null, "04/04/2024 22.24.02" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "DeliveryCoordinates", "DeliveryDate" },
                values: new object[] { null, "05/04/2024 00.24.02" });
        }
    }
}
