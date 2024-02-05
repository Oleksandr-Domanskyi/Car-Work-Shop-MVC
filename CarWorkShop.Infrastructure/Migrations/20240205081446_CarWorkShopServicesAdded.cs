using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarWorkShopServicesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarWorkShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_CarWorkShops_CarWorkShopId",
                        column: x => x.CarWorkShopId,
                        principalTable: "CarWorkShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CarWorkShopId",
                table: "Services",
                column: "CarWorkShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
