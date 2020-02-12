using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateProductsAddProductsPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductsPhotos_ProductsId",
                table: "ProductsPhotos",
                column: "ProductsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPhotos_Products_ProductsId",
                table: "ProductsPhotos",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "ProductsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPhotos_Products_ProductsId",
                table: "ProductsPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProductsPhotos_ProductsId",
                table: "ProductsPhotos");
        }
    }
}
