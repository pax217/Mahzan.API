using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTicketsAddPaymentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTypesId",
                table: "Tickets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PaymentTypesId",
                table: "Tickets",
                column: "PaymentTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PaymentTypes_PaymentTypesId",
                table: "Tickets",
                column: "PaymentTypesId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PaymentTypes_PaymentTypesId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PaymentTypesId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PaymentTypesId",
                table: "Tickets");
        }
    }
}
