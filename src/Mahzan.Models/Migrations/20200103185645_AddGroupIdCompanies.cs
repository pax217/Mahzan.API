using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class AddGroupIdCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Groups_GroupId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_GroupId",
                table: "Companies");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupsId",
                table: "Companies",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Companies_GroupId",
                table: "Companies",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Groups_GroupId",
                table: "Companies",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
