using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdatePointsOfSalesRelashionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsOfSales_Stores_StoresId",
                table: "PointsOfSales");

            migrationBuilder.DropIndex(
                name: "IX_PointsOfSales_StoresId",
                table: "PointsOfSales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PointsOfSales_StoresId",
                table: "PointsOfSales",
                column: "StoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsOfSales_Stores_StoresId",
                table: "PointsOfSales",
                column: "StoresId",
                principalTable: "Stores",
                principalColumn: "StoresId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
