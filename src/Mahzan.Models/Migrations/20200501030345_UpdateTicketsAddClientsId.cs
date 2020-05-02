using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateTicketsAddClientsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientsId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommercialName",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CommercialName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
