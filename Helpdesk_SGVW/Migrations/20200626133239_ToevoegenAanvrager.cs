using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class ToevoegenAanvrager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Aanvrager",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aanvrager",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Aangemaak door ID",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersoneelId",
                table: "Ticket",
                type: "int",
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
    }
}
