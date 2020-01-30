using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTicketDetailChangeTicketDetailId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDetail",
                table: "TicketDetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TicketDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketDetailId",
                table: "TicketDetail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDetail",
                table: "TicketDetail",
                column: "TicketDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDetail",
                table: "TicketDetail");

            migrationBuilder.DropColumn(
                name: "TicketDetailId",
                table: "TicketDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TicketDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDetail",
                table: "TicketDetail",
                column: "Id");
        }
    }
}
