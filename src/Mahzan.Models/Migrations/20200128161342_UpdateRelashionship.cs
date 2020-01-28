using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateRelashionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Groups_GroupsId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Members_MembersId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Companies_CompaniesId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CompaniesId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Groups_MembersId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Companies_GroupsId",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stores_CompaniesId",
                table: "Stores",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_MembersId",
                table: "Groups",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_GroupsId",
                table: "Companies",
                column: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Groups_GroupsId",
                table: "Companies",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "GroupsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Members_MembersId",
                table: "Groups",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Companies_CompaniesId",
                table: "Stores",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "CompaniesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
