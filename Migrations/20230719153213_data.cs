using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsInfo.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "ProductType", "PurchaseDate", "State" },
                values: new object[,]
                {
                    { 3, "Chevrolet Tracker 2022", 125000000m, "Vehiculos", new DateTimeOffset(new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Active" },
                    { 4, "Casa Usaquen", 700000000m, "Apartamentos", new DateTimeOffset(new DateTime(2005, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Active" },
                    { 5, "Anillo Oro", 1500000m, "Bienes", new DateTimeOffset(new DateTime(2010, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Inactive" },
                    { 6, "Lote Sogamoso, Boyacá", 110000000m, "Terrenos", new DateTimeOffset(new DateTime(1998, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Active" },
                    { 7, "Lote Moniquira, Boyaca", 90000000m, "Terrenos", new DateTimeOffset(new DateTime(2013, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Active" },
                    { 8, "Reloj Rolex 1995", 12000000m, "Bienes", new DateTimeOffset(new DateTime(1996, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Active" },
                    { 9, "Mazda 6 2008", 25000000m, "Vehiculos", new DateTimeOffset(new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
