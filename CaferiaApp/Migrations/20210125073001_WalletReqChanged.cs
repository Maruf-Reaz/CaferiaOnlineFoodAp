using Microsoft.EntityFrameworkCore.Migrations;

namespace CaferiaApp.Migrations
{
    public partial class WalletReqChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "WalletRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "WalletRequests");
        }
    }
}
