using Microsoft.EntityFrameworkCore.Migrations;

namespace CaferiaApp.Migrations
{
    public partial class ItemCatIntoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCatagories_ItemCatagoryId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCatagoryId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCatagories_ItemCatagoryId",
                table: "Items",
                column: "ItemCatagoryId",
                principalTable: "ItemCatagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCatagories_ItemCatagoryId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCatagoryId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCatagories_ItemCatagoryId",
                table: "Items",
                column: "ItemCatagoryId",
                principalTable: "ItemCatagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
