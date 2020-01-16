using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class CreateMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    MenuItemId = table.Column<Guid>(nullable: false),
                    MenuSubItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Section = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Root = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Page = table.Column<string>(nullable: true),
                    Bullet = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu_SubItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Page = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Menu_ItemsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_SubItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_SubItems_Menu_Items_Menu_ItemsId",
                        column: x => x.Menu_ItemsId,
                        principalTable: "Menu_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_SubItems_Menu_ItemsId",
                table: "Menu_SubItems",
                column: "Menu_ItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Menu_SubItems");

            migrationBuilder.DropTable(
                name: "Menu_Items");
        }
    }
}
