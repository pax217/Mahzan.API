using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTaxesStoresAddTaxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Taxes_Stores_TaxesId",
                table: "Taxes_Stores",
                column: "TaxesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_Stores_Taxes_TaxesId",
                table: "Taxes_Stores",
                column: "TaxesId",
                principalTable: "Taxes",
                principalColumn: "TaxesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_Stores_Taxes_TaxesId",
                table: "Taxes_Stores");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_Stores_TaxesId",
                table: "Taxes_Stores");
        }
    }
}
