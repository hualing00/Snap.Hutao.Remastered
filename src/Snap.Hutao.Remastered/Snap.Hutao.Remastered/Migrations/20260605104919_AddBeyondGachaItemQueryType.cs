using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snap.Hutao.Remastered.Migrations
{
    /// <inheritdoc />
    public partial class AddBeyondGachaItemQueryType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "beyond_gacha_items");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "beyond_gacha_items");

            migrationBuilder.AddColumn<int>(
                name: "QueryType",
                table: "beyond_gacha_items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            // Convert existing GachaType to QueryType:
            // UGCActivityAvatarMaleOne(20011)/MaleTwo(20012)/FemaleOne(20021)/FemaleTwo(20022) -> UGCAvatarEventWish(2000)
            // All others map to themselves
            // Regular gacha types (100/200/301/302/400/500) are not expected in beyond_gacha_items
            migrationBuilder.Sql("UPDATE beyond_gacha_items SET QueryType = 2000 WHERE GachaType IN (20011, 20012, 20021, 20022)");
            migrationBuilder.Sql("UPDATE beyond_gacha_items SET QueryType = GachaType WHERE QueryType = 1000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueryType",
                table: "beyond_gacha_items");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "beyond_gacha_items",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "beyond_gacha_items",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
