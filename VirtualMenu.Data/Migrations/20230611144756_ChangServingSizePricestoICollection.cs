using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualMenu.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangServingSizePricestoICollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    activeStatus = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ServingSizePrices",
                columns: table => new
                {
                    servingSizeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    orderSequence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    servingSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceStr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServingSizePrices", x => x.servingSizeId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    activeStatus = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastAccessed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemServingSizePrices",
                columns: table => new
                {
                    itemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    servingSizePricesservingSizeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemServingSizePrices", x => new { x.itemId, x.servingSizePricesservingSizeId });
                    table.ForeignKey(
                        name: "FK_ItemServingSizePrices_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemServingSizePrices_ServingSizePrices_servingSizePricesservingSizeId",
                        column: x => x.servingSizePricesservingSizeId,
                        principalTable: "ServingSizePrices",
                        principalColumn: "servingSizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_categoryid",
                table: "Items",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_ItemServingSizePrices_servingSizePricesservingSizeId",
                table: "ItemServingSizePrices",
                column: "servingSizePricesservingSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemServingSizePrices");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ServingSizePrices");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
