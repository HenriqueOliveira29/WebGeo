using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGeoRepository.Migrations
{
    /// <inheritdoc />
    public partial class addStorageRestock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeliverToClient",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageRestockId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StorageRestockId",
                table: "Orders",
                column: "StorageRestockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Storages_StorageRestockId",
                table: "Orders",
                column: "StorageRestockId",
                principalTable: "Storages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Storages_StorageRestockId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StorageRestockId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateDeliverToClient",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StorageRestockId",
                table: "Orders");
        }
    }
}
