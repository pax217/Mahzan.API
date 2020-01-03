using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class RemoveCompaniesFromGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Groups_GroupsId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_GroupsId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupsId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_GroupsId",
                table: "Companies",
                column: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Groups_GroupsId",
                table: "Companies",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
