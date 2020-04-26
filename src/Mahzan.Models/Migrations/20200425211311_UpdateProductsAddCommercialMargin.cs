using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateProductsAddCommercialMargin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CommercialMargin",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommercialMarginPercentaje",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommercialMargin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CommercialMarginPercentaje",
                table: "Products");
        }
    }
}
