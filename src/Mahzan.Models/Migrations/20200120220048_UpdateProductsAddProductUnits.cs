using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateProductsAddProductUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductUnitsId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductUnitsId",
                table: "Products",
                column: "ProductUnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductUnits_ProductUnitsId",
                table: "Products",
                column: "ProductUnitsId",
                principalTable: "ProductUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductUnits_ProductUnitsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductUnitsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductUnitsId",
                table: "Products");
        }
    }
}
