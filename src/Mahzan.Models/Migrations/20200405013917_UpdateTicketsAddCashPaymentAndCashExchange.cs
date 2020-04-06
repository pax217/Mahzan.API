using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTicketsAddCashPaymentAndCashExchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CashExchange",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashPayment",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashExchange",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CashPayment",
                table: "Tickets");
        }
    }
}
