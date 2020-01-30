using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateProductsTaxesAddTaxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductsTaxes_TaxesId",
                table: "ProductsTaxes",
                column: "TaxesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTaxes_Taxes_TaxesId",
                table: "ProductsTaxes",
                column: "TaxesId",
                principalTable: "Taxes",
                principalColumn: "TaxesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTaxes_Taxes_TaxesId",
                table: "ProductsTaxes");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTaxes_TaxesId",
                table: "ProductsTaxes");
        }
    }
}
