using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsInfo.Migrations
{
    /// <inheritdoc />
    public partial class updatetypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductType",
                value: "Vehiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductType",
                value: "vehículos");
        }
    }
}
