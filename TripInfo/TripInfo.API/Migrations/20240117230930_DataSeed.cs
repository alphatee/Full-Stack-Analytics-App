using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Address", "Boost", "City", "Country", "Customer10Price", "Customer10ServiceFee", "Customer10Tip", "Customer1Price", "Customer1ServiceFee", "Customer1Tip", "Customer2Price", "Customer2ServiceFee", "Customer2Tip", "Customer3Price", "Customer3ServiceFee", "Customer3Tip", "Customer4Price", "Customer4ServiceFee", "Customer4Tip", "Customer5Price", "Customer5ServiceFee", "Customer5Tip", "Customer6Price", "Customer6ServiceFee", "Customer6Tip", "Customer7Price", "Customer7ServiceFee", "Customer7Tip", "Customer8Price", "Customer8ServiceFee", "Customer8Tip", "Customer9Price", "Customer9ServiceFee", "Customer9Tip", "CustomerPaymentsTotal", "DateTime", "Distance", "Duration", "Fare", "PointsEarned", "Promotion", "ServiceFeeTotal", "State", "StoreName", "Street", "Tip", "YourEarnings", "Zip" },
                values: new object[,]
                {
                    { 1, "Pacific Hwy, San Diego, CA 92101-1128, US", 0.0, "San Diego", "US", 0.0, 0.0, 0.0, 22.149999999999999, 13.630000000000001, 6.5599999999999996, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 28.710000000000001, new DateTime(2023, 7, 3, 11, 23, 0, 0, DateTimeKind.Unspecified), 12.6, new TimeSpan(0, 0, 33, 21, 0), 8.5199999999999996, 3, 0.0, 13.630000000000001, "CA", "Coco Ichibanya Curry House (San Diego) ", "Pacific Hwy", 6.5599999999999996, 15.08, "92101-1128" },
                    { 2, "Butternut Ln, San Diego, CA 92123, USA", 1.28, "San Diego", "USA", 0.0, 0.0, 0.0, 12.99, 3.8700000000000001, 5.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 18.489999999999998, new DateTime(2023, 7, 3, 20, 27, 0, 0, DateTimeKind.Unspecified), 7.4000000000000004, new TimeSpan(0, 0, 21, 11, 0), 7.8399999999999999, 6, 1.28, 3.8700000000000001, "CA", "Adam's Wine & Spirits ", "Butternut Ln", 5.5, 14.619999999999999, "92123" },
                    { 3, "Convoy Ct, San Diego, CA 92111, USA", 0.23999999999999999, "San Diego", "USA", 0.0, 0.0, 0.0, 9.3000000000000007, 4.3799999999999999, 17.23, 10.49, 5.3200000000000003, 22.68, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 59.700000000000003, new DateTime(2023, 7, 7, 11, 25, 0, 0, DateTimeKind.Unspecified), 9.9000000000000004, new TimeSpan(0, 0, 48, 49, 0), 9.8499999999999996, 6, 0.23999999999999999, 9.6999999999999993, "CA", "Mendocino Farms ", "Convoy Ct", 39.909999999999997, 50.0, "92111" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerPrice", "CustomerServiceFee", "CustomerTip", "Description", "TripId" },
                values: new object[,]
                {
                    { 1, 22.149999999999999, 13.630000000000001, 6.5599999999999996, "Customer 1 Description", 1 },
                    { 2, 12.99, 3.8700000000000001, 5.5, "Customer 2 Description", 2 },
                    { 3, 9.3000000000000007, 4.3799999999999999, 17.23, "Customer 1 Description", 3 },
                    { 4, 10.49, 5.3200000000000003, 22.68, "Customer 2 Description", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
