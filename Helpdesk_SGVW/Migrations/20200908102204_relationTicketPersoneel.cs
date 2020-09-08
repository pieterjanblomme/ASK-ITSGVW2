using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class relationTicketPersoneel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Ticket_Opvolgers_BeheerderId",
            //    table: "Ticket");

            //migrationBuilder.DropIndex(
            //    name: "IX_Ticket_BeheerderId",
            //    table: "Ticket");

            //migrationBuilder.DropColumn(
            //    name: "BeheerderId",
            //    table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "AanvragerId",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AanvragerId",
                table: "Ticket",
                column: "AanvragerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Personeel_AanvragerId",
                table: "Ticket",
                column: "AanvragerId",
                principalTable: "Personeel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Personeel_AanvragerId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_AanvragerId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "AanvragerId",
                table: "Ticket");

            //migrationBuilder.AddColumn<int>(
            //    name: "BeheerderId",
            //    table: "Ticket",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Ticket_BeheerderId",
            //    table: "Ticket",
            //    column: "BeheerderId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Ticket_Opvolgers_BeheerderId",
            //    table: "Ticket",
            //    column: "BeheerderId",
            //    principalTable: "Opvolgers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
