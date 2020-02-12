using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateProductsPhotosId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsPhotos",
                table: "ProductsPhotos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductsPhotos");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductsPhotos");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsPhotosId",
                table: "ProductsPhotos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsId",
                table: "ProductsPhotos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsPhotos",
                table: "ProductsPhotos",
                column: "ProductsPhotosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsPhotos",
                table: "ProductsPhotos");

            migrationBuilder.DropColumn(
                name: "ProductsPhotosId",
                table: "ProductsPhotos");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "ProductsPhotos");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductsPhotos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductsPhotos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsPhotos",
                table: "ProductsPhotos",
                column: "Id");
        }
    }
}
