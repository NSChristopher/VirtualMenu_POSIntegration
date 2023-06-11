using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualMenu.Data.Migrations
{
    /// <inheritdoc />
    public partial class reomveorderseqservingsize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderSequence",
                table: "ServingSizePrices");

            migrationBuilder.DropColumn(
                name: "servingSize",
                table: "ServingSizePrices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "orderSequence",
                table: "ServingSizePrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "servingSize",
                table: "ServingSizePrices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
