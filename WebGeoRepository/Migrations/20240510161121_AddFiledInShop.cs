﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGeoRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddFiledInShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InShop",
                table: "ProductOrders",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InShop",
                table: "ProductOrders");
        }
    }
}
