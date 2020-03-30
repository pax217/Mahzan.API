using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateMembersAddMembersPatternIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MembersPatternId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Stores_EmployeesId",
                table: "Employees_Stores",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Stores_Employees_EmployeesId",
                table: "Employees_Stores",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "EmployeesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Stores_Employees_EmployeesId",
                table: "Employees_Stores");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Stores_EmployeesId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "MembersPatternId",
                table: "Members");
        }
    }
}
