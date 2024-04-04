using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    /// <inheritdoc />
    public partial class MakeDeliveryCoordiantesPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryCoordinates",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "DeliveryCoordinates", "DeliveryDate" },
                values: new object[] { "56.1833, 10.2039", "04/04/2024 20.24.02" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryCoordinates",
                table: "Orders");

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
    }
}
