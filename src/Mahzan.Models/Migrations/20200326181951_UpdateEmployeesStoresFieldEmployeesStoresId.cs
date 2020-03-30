using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateEmployeesStoresFieldEmployeesStoresId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees_Stores",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employees_Stores");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeesStoresId",
                table: "Employees_Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees_Stores",
                table: "Employees_Stores",
                column: "EmployeesStoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees_Stores",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "EmployeesStoresId",
                table: "Employees_Stores");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Employees_Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees_Stores",
                table: "Employees_Stores",
                column: "Id");
        }
    }
}
