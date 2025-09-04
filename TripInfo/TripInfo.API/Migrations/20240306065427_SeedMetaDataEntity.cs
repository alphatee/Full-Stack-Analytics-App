using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMetaDataEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Address", "Boost", "City", "Country", "Customer10Price", "Customer10ServiceFee", "Customer10Tip", "Customer1Price", "Customer1ServiceFee", "Customer1Tip", "Customer2Price", "Customer2ServiceFee", "Customer2Tip", "Customer3Price", "Customer3ServiceFee", "Customer3Tip", "Customer4Price", "Customer4ServiceFee", "Customer4Tip", "Customer5Price", "Customer5ServiceFee", "Customer5Tip", "Customer6Price", "Customer6ServiceFee", "Customer6Tip", "Customer7Price", "Customer7ServiceFee", "Customer7Tip", "Customer8Price", "Customer8ServiceFee", "Customer8Tip", "Customer9Price", "Customer9ServiceFee", "Customer9Tip", "CustomerPaymentsTotal", "DateTime", "Distance", "Duration", "Fare", "PointsEarned", "Promotion", "ServiceFeeTotal", "State", "StoreName", "Street", "Tip", "YourEarnings", "Zip" },
                values: new object[,]
                {
                    { -6, "Butternut Ln, San Diego, CA 92123, USA", 0.0, "San Diego", "USA", 0.0, 0.0, 0.0, 17.84, 3.8700000000000001, 15.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 37.210000000000001, new DateTime(2023, 7, 2, 20, 27, 0, 0, DateTimeKind.Unspecified), 1.3999999999999999, new TimeSpan(0, 0, 9, 21, 0), 17.84, 3, 0.0, 3.8700000000000001, "CA", "Adam's Wine & Spirits ", "Butternut Ln", 15.5, 33.340000000000003, "92123" },
                    { -5, "Convoy Ct, San Diego, CA 92111, USA", 0.0, "San Diego", "USA", 0.0, 0.0, 0.0, 2.25, 4.3799999999999999, 5.0, 2.0, 5.3200000000000003, 5.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 23.949999999999999, new DateTime(2023, 7, 4, 9, 13, 0, 0, DateTimeKind.Unspecified), 5.9000000000000004, new TimeSpan(0, 0, 16, 49, 0), 4.25, 6, 0.0, 9.6999999999999993, "CA", "Mendocino Farms ", "Convoy Ct", 10.0, 14.25, "92111" },
                    { -4, "Convoy Ct, San Diego, CA 92111, USA", 0.0, "San Diego", "USA", 0.0, 0.0, 0.0, 1.0, 4.3799999999999999, 8.1099999999999994, 1.8500000000000001, 5.3200000000000003, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 21.66, new DateTime(2023, 7, 8, 10, 15, 0, 0, DateTimeKind.Unspecified), 2.8999999999999999, new TimeSpan(0, 0, 22, 19, 0), 2.8500000000000001, 6, 0.0, 9.6999999999999993, "CA", "Mendocino Farms ", "Convoy Ct", 9.1099999999999994, 11.960000000000001, "92111" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerPrice", "CustomerServiceFee", "CustomerTip", "Description", "TripId" },
                values: new object[,]
                {
                    { -9, 17.84, 3.8700000000000001, 15.5, "Customer 1 Description", -6 },
                    { -8, 2.0, 5.3200000000000003, 5.0, "Customer 2 Description", -5 },
                    { -7, 2.25, 4.3799999999999999, 5.0, "Customer 1 Description", -5 },
                    { -6, 1.8500000000000001, 5.3200000000000003, 1.0, "Customer 2 Description", -4 },
                    { -5, 1.0, 4.3799999999999999, 8.1099999999999994, "Customer 1 Description", -4 }
                });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "Id", "Address", "Boost", "City", "Country", "DateTime", "Distance", "Duration", "Fare", "PointsEarned", "Promotion", "State", "StoreName", "Street", "Tip", "TripId", "YourEarnings", "Zip" },
                values: new object[,]
                {
                    { -6, "Butternut Ln, San Diego, CA 92123, USA", 0.0, "San Diego", "USA", new DateTime(2023, 7, 2, 20, 27, 0, 0, DateTimeKind.Unspecified), 1.3999999999999999, new TimeSpan(0, 0, 9, 21, 0), 17.84, 3, 0.0, "CA", "Adam's Wine & Spirits ", "Butternut Ln", 15.5, -6, 33.340000000000003, "92123" },
                    { -5, "Convoy Ct, San Diego, CA 92111, USA", 0.0, "San Diego", "USA", new DateTime(2023, 7, 4, 9, 13, 0, 0, DateTimeKind.Unspecified), 5.9000000000000004, new TimeSpan(0, 0, 16, 49, 0), 4.25, 6, 0.0, "CA", "Mendocino Farms ", "Convoy Ct", 10.0, -5, 14.25, "92111" },
                    { -4, "Convoy Ct, San Diego, CA 92111, USA", 0.0, "San Diego", "USA", new DateTime(2023, 7, 8, 10, 15, 0, 0, DateTimeKind.Unspecified), 2.8999999999999999, new TimeSpan(0, 0, 22, 19, 0), 2.8500000000000001, 6, 0.0, "CA", "Mendocino Farms ", "Convoy Ct", 9.1099999999999994, -4, 11.960000000000001, "92111" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: -4);
        }
    }
}
