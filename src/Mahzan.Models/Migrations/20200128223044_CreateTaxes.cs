using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class CreateTaxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxesId = table.Column<Guid>(nullable: false),
                    TaxRate = table.Column<decimal>(nullable: false),
                    TaxType = table.Column<int>(nullable: false),
                    MembersId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxesId);
                });

            migrationBuilder.CreateTable(
                name: "Taxes_Stores",
                columns: table => new
                {
                    TaxesStoresId = table.Column<Guid>(nullable: false),
                    TaxesId = table.Column<Guid>(nullable: false),
                    StoresId = table.Column<Guid>(nullable: false),
                    MembersId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes_Stores", x => x.TaxesStoresId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Taxes_Stores");
        }
    }
}
