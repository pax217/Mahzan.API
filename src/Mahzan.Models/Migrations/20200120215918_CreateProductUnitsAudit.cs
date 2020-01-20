using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class CreateProductUnitsAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductUnits_Audit",
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
                    table.PrimaryKey("PK_ProductUnits_Audit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUnits_Audit");
        }
    }
}
