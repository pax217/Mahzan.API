using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateEmployeesAddAspNetUsersId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AspNetUsersId",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Employees");
        }
    }
}
