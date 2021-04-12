using Microsoft.EntityFrameworkCore.Migrations;

namespace CaferiaApp.Migrations
{
    public partial class WalletReqApprovedAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ApprovedAmount",
                table: "WalletRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAmount",
                table: "WalletRequests");
        }
    }
}
