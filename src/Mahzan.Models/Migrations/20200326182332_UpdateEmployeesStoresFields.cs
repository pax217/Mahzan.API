using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateEmployeesStoresFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Employees_Stores");

            migrationBuilder.AddColumn<Guid>(
                name: "CompaniesId",
                table: "Employees_Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeesId",
                table: "Employees_Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembersId",
                table: "Employees_Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StoresId",
                table: "Employees_Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompaniesId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "MembersId",
                table: "Employees_Stores");

            migrationBuilder.DropColumn(
                name: "StoresId",
                table: "Employees_Stores");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees_Stores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Employees_Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Employees_Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Employees_Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Employees_Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
