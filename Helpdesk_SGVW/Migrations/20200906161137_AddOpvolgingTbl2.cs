﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    //public partial class AddOpvolgingTbl2 : Migration
    //{
    //    protected override void Up(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.DropForeignKey(
    //            name: "FK_Ticket_Opvolgers_OpvolgingId",
    //            table: "Ticket");

    //        migrationBuilder.DropIndex(
    //            name: "IX_Ticket_OpvolgingId",
    //            table: "Ticket");

    //        migrationBuilder.DropColumn(
    //            name: "OpvolgingId",
    //            table: "Ticket");

    //        migrationBuilder.DropColumn(
    //            name: "OpvolingId",
    //            table: "Ticket");
    //    }

    //    protected override void Down(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.AddColumn<int>(
    //            name: "OpvolgingId",
    //            table: "Ticket",
    //            type: "int",
    //            nullable: true);

    //        migrationBuilder.AddColumn<int>(
    //            name: "OpvolingId",
    //            table: "Ticket",
    //            type: "int",
    //            nullable: false,
    //            defaultValue: 0);

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Ticket_OpvolgingId",
    //            table: "Ticket",
    //            column: "OpvolgingId");

    //        migrationBuilder.AddForeignKey(
    //            name: "FK_Ticket_Opvolgers_OpvolgingId",
    //            table: "Ticket",
    //            column: "OpvolgingId",
    //            principalTable: "Opvolgers",
    //            principalColumn: "Id",
    //            onDelete: ReferentialAction.Restrict);
    //    }
   // }
}
