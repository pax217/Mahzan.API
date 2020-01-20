using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class CreateProductCategoriesAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductUnitId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoriesId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCategories_Audit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AspNetUserId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTimeOffset>(nullable: false),
                    KeyValues = table.Column<string>(nullable: true),
                    OldValues = table.Column<string>(nullable: true),
                    NewValues = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories_Audit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoriesId",
                table: "Products",
                column: "ProductCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoriesId",
                table: "Products",
                column: "ProductCategoriesId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoriesId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories_Audit");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoriesId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductUnitId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
