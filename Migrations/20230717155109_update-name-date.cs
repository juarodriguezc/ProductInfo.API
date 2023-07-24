﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsInfo.Migrations
{
    /// <inheritdoc />
    public partial class updatenamedate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseTime",
                table: "Products",
                newName: "PurchaseDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Products",
                newName: "PurchaseTime");
        }
    }
}
