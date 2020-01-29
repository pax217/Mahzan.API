using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class CreateProductsTaxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsTaxes",
                columns: table => new
                {
                    ProductsTaxesId = table.Column<Guid>(nullable: false),
                    ProductsId = table.Column<Guid>(nullable: false),
                    TaxesId = table.Column<Guid>(nullable: false),
                    MembersId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTaxes", x => x.ProductsTaxesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsTaxes");
        }
    }
}
