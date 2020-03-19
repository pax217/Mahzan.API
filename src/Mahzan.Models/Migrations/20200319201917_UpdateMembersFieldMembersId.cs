using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahzan.Models.Migrations
{
    public partial class UpdateMembersFieldMembersId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Members_MembersId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Members_MembersId",
                table: "PaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Members_MembersId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "MembersId",
                table: "Members",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Members_MembersId",
                table: "Clients",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "MembersId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Members_MembersId",
                table: "PaymentTypes",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "MembersId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Members_MembersId",
                table: "Products",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "MembersId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Members_MembersId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Members_MembersId",
                table: "PaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Members_MembersId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MembersId",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Members_MembersId",
                table: "Clients",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Members_MembersId",
                table: "PaymentTypes",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Members_MembersId",
                table: "Products",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
