using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<double>(type: "float", nullable: false),
                    Promotion = table.Column<double>(type: "float", nullable: false),
                    Boost = table.Column<double>(type: "float", nullable: false),
                    Tip = table.Column<double>(type: "float", nullable: false),
                    YourEarnings = table.Column<double>(type: "float", nullable: false),
                    Customer1Price = table.Column<double>(type: "float", nullable: false),
                    Customer1Tip = table.Column<double>(type: "float", nullable: false),
                    Customer1ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer2Price = table.Column<double>(type: "float", nullable: false),
                    Customer2Tip = table.Column<double>(type: "float", nullable: false),
                    Customer2ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer3Price = table.Column<double>(type: "float", nullable: false),
                    Customer3Tip = table.Column<double>(type: "float", nullable: false),
                    Customer3ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer4Price = table.Column<double>(type: "float", nullable: false),
                    Customer4Tip = table.Column<double>(type: "float", nullable: false),
                    Customer4ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer5Price = table.Column<double>(type: "float", nullable: false),
                    Customer5Tip = table.Column<double>(type: "float", nullable: false),
                    Customer5ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer6Price = table.Column<double>(type: "float", nullable: false),
                    Customer6Tip = table.Column<double>(type: "float", nullable: false),
                    Customer6ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer7Price = table.Column<double>(type: "float", nullable: false),
                    Customer7Tip = table.Column<double>(type: "float", nullable: false),
                    Customer7ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer8Price = table.Column<double>(type: "float", nullable: false),
                    Customer8Tip = table.Column<double>(type: "float", nullable: false),
                    Customer8ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer9Price = table.Column<double>(type: "float", nullable: false),
                    Customer9Tip = table.Column<double>(type: "float", nullable: false),
                    Customer9ServiceFee = table.Column<double>(type: "float", nullable: false),
                    Customer10Price = table.Column<double>(type: "float", nullable: false),
                    Customer10Tip = table.Column<double>(type: "float", nullable: false),
                    Customer10ServiceFee = table.Column<double>(type: "float", nullable: false),
                    CustomerPaymentsTotal = table.Column<double>(type: "float", nullable: false),
                    ServiceFeeTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPrice = table.Column<double>(type: "float", nullable: false),
                    CustomerTip = table.Column<double>(type: "float", nullable: false),
                    CustomerServiceFee = table.Column<double>(type: "float", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TripId",
                table: "Customers",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
