using Microsoft.EntityFrameworkCore.Migrations;

namespace CaferiaApp.Migrations
{
    public partial class ItemMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasOption1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HasOption2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HasOption3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Option1Name",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Option1Price",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Option2Name",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Option2Price",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Option3Name",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Option3Price",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PriceOptionAvailable",
                table: "Items",
                newName: "IsInStock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInStock",
                table: "Items",
                newName: "PriceOptionAvailable");

            migrationBuilder.AddColumn<bool>(
                name: "HasOption1",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasOption2",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasOption3",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Option1Name",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Option1Price",
                table: "Items",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Option2Name",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Option2Price",
                table: "Items",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Option3Name",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Option3Price",
                table: "Items",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
