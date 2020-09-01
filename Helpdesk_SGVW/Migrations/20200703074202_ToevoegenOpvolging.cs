using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class ToevoegenOpvolging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "Opvolger",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Uitleg",
                table: "Ticket",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opvolger",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Uitleg",
                table: "Ticket");


        }
    }
}
