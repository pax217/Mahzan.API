using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTicketDetailTaxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxOption",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "TaxType",
                table: "Taxes");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountTax",
                table: "TicketDetailTaxes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Taxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Printed",
                table: "Taxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRatePercentage",
                table: "Taxes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "TaxRateVariable",
                table: "Taxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Taxes",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AvailableInAllStores",
                table: "Products",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountTax",
                table: "TicketDetailTaxes");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Printed",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "TaxRatePercentage",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "TaxRateVariable",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Taxes");

            migrationBuilder.AddColumn<string>(
                name: "TaxOption",
                table: "Taxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                table: "Taxes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TaxType",
                table: "Taxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "AvailableInAllStores",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
