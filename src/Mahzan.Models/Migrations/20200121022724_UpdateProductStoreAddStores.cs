using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateProductStoreAddStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoresId",
                table: "Products_Store",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_Store_StoresId",
                table: "Products_Store",
                column: "StoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Store_Stores_StoresId",
                table: "Products_Store",
                column: "StoresId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Store_Stores_StoresId",
                table: "Products_Store");

            migrationBuilder.DropIndex(
                name: "IX_Products_Store_StoresId",
                table: "Products_Store");

            migrationBuilder.DropColumn(
                name: "StoresId",
                table: "Products_Store");
        }
    }
}
