using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class ToevoegenPersoneelDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aangemaak door ID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersoneelId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Aangemaak door ID",
                table: "Ticket",
                column: "Aangemaak door ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Personeel_Aangemaak door ID",
                table: "Ticket",
                column: "Aangemaak door ID",
                principalTable: "Personeel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Personeel_Aangemaak door ID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_Aangemaak door ID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Aangemaak door ID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PersoneelId",
                table: "Ticket");
        }
    }
}
