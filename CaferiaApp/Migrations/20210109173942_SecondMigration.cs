using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaferiaApp.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryBoys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    IdNo = table.Column<string>(nullable: true),
                    PhotoName1 = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBoys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PhotoName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCatagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RequestAmount = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletRequests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Descripton = table.Column<string>(nullable: true),
                    HasOption1 = table.Column<bool>(nullable: false),
                    HasOption2 = table.Column<bool>(nullable: false),
                    HasOption3 = table.Column<bool>(nullable: false),
                    Option1Name = table.Column<string>(nullable: true),
                    Option2Name = table.Column<string>(nullable: true),
                    Option3Name = table.Column<string>(nullable: true),
                    Option1Price = table.Column<double>(nullable: false),
                    Option2Price = table.Column<double>(nullable: false),
                    Option3Price = table.Column<double>(nullable: false),
                    PhotoName1 = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    ItemCatagoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCatagories_ItemCatagoryId",
                        column: x => x.ItemCatagoryId,
                        principalTable: "ItemCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCatagoryId",
                table: "Items",
                column: "ItemCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletRequests_ApplicationUserId",
                table: "WalletRequests",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryBoys");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WalletRequests");

            migrationBuilder.DropTable(
                name: "ItemCatagories");
        }
    }
}
