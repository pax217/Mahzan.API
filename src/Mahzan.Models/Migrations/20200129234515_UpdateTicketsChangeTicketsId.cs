using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTicketsChangeTicketsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetail_Tickets_TicketsId",
                table: "TicketDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketsId",
                table: "Tickets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetail_Tickets_TicketsId",
                table: "TicketDetail",
                column: "TicketsId",
                principalTable: "Tickets",
                principalColumn: "TicketsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetail_Tickets_TicketsId",
                table: "TicketDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketsId",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetail_Tickets_TicketsId",
                table: "TicketDetail",
                column: "TicketsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
