using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdatePointsOfSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Groups");

            migrationBuilder.AddColumn<Guid>(
                name: "MembersId",
                table: "Groups",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Groups_MembersId",
                table: "Groups",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Members_MembersId",
                table: "Groups",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Members_MembersId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_MembersId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "MembersId",
                table: "Groups");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Groups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
