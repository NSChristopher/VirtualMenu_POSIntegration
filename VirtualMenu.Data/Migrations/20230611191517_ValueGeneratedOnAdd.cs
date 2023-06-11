using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualMenu.Data.Migrations
{
    /// <inheritdoc />
    public partial class ValueGeneratedOnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemServingSizePrices");

            migrationBuilder.AddColumn<string>(
                name: "itemId",
                table: "ServingSizePrices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServingSizePrices_itemId",
                table: "ServingSizePrices",
                column: "itemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServingSizePrices_Items_itemId",
                table: "ServingSizePrices",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "itemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServingSizePrices_Items_itemId",
                table: "ServingSizePrices");

            migrationBuilder.DropIndex(
                name: "IX_ServingSizePrices_itemId",
                table: "ServingSizePrices");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "ServingSizePrices");

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
                name: "IX_ItemServingSizePrices_servingSizePricesservingSizeId",
                table: "ItemServingSizePrices",
                column: "servingSizePricesservingSizeId");
        }
    }
}
