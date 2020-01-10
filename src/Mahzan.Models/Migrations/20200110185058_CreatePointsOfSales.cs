using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class CreatePointsOfSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointsOfSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsOfSales_Audit",
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
                    table.PrimaryKey("PK_PointsOfSales_Audit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsOfSales");

            migrationBuilder.DropTable(
                name: "PointsOfSales_Audit");
        }
    }
}
