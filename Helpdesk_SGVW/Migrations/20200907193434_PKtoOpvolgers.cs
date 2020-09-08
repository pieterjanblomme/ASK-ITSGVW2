using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    //public partial class PKtoOpvolgers : Migration
    //{
    //    protected override void Up(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.AddColumn<int>(
    //            name: "BeheerderId",
    //            table: "Ticket",
    //            nullable: false,
    //            defaultValue: 0);

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Ticket_BeheerderId",
    //            table: "Ticket",
    //            column: "BeheerderId");

    //        migrationBuilder.AddForeignKey(
    //            name: "FK_Ticket_Opvolgers_BeheerderId",
    //            table: "Ticket",
    //            column: "BeheerderId",
    //            principalTable: "Opvolgers",
    //            principalColumn: "Id",
    //            onDelete: ReferentialAction.NoAction);
    //    }

    //    protected override void Down(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.DropForeignKey(
    //            name: "FK_Ticket_Opvolgers_BeheerderId",
    //            table: "Ticket");

    //        migrationBuilder.DropIndex(
    //            name: "IX_Ticket_BeheerderId",
    //            table: "Ticket");

    //        migrationBuilder.DropColumn(
    //            name: "BeheerderId",
    //            table: "Ticket");
    //    }
    //}
}
