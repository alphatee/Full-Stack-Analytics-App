using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedCustomerDescriptiontoCustomer1forId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Customer 1 Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Customer 2 Description");
        }
    }
}
