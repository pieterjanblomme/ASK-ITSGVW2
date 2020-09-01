using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class ToevoegenMailCategorieSubcategorieAanvrager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAanvrager",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verantwoordelijke",
                table: "SubCategorie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verantwoordelijke",
                table: "Categorie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAanvrager",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Verantwoordelijke",
                table: "SubCategorie");

            migrationBuilder.DropColumn(
                name: "Verantwoordelijke",
                table: "Categorie");
        }
    }
}
