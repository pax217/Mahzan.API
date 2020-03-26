using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdatePaymentTypesFieldId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PaymentTypes_PaymentTypesId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PaymentTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTypesId",
                table: "PaymentTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes",
                column: "PaymentTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PaymentTypes_PaymentTypesId",
                table: "Tickets",
                column: "PaymentTypesId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PaymentTypes_PaymentTypesId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "PaymentTypesId",
                table: "PaymentTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PaymentTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PaymentTypes_PaymentTypesId",
                table: "Tickets",
                column: "PaymentTypesId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
