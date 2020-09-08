using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class relationOpvolgersPersoneel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpvolgerId",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OpvolgerId",
                table: "Ticket",
                column: "OpvolgerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Personeel_OpvolgerId",
                table: "Ticket",
                column: "OpvolgerId",
                principalTable: "Personeel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Personeel_OpvolgerId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_OpvolgerId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "OpvolgerId",
                table: "Ticket");
        }
    }
}
