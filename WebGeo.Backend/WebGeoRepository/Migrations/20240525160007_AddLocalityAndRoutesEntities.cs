using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebGeoRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalityAndRoutesEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Shops");

            migrationBuilder.AddColumn<int>(
                name: "LocalityId",
                table: "Storages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalityId",
                table: "Shops",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<Geometry>(type: "geometry(Point, 3763)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    DestinyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Localities_DestinyId",
                        column: x => x.DestinyId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Localities_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storages_LocalityId",
                table: "Storages",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_LocalityId",
                table: "Shops",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestinyId",
                table: "Routes",
                column: "DestinyId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_OriginId",
                table: "Routes",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Localities_LocalityId",
                table: "Shops",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Localities_LocalityId",
                table: "Storages",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Localities_LocalityId",
                table: "Shops");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Localities_LocalityId",
                table: "Storages");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropIndex(
                name: "IX_Storages_LocalityId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_Shops_LocalityId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "Shops");

            migrationBuilder.AddColumn<Geometry>(
                name: "Location",
                table: "Storages",
                type: "geometry(Point, 4326)",
                nullable: false);

            migrationBuilder.AddColumn<Geometry>(
                name: "Location",
                table: "Shops",
                type: "geometry(Point, 4326)",
                nullable: false);
        }
    }
}
