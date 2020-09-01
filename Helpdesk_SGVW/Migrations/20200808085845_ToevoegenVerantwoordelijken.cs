using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class ToevoegenVerantwoordelijken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Verantwoordelijke2",
                table: "SubCategorie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verantwoordelijke",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verantwoordelijke2",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verantwoordelijke2",
                table: "Categorie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verantwoordelijke2",
                table: "SubCategorie");

            migrationBuilder.DropColumn(
                name: "Verantwoordelijke",
                table: "School");

            migrationBuilder.DropColumn(
                name: "Verantwoordelijke2",
                table: "School");

            migrationBuilder.DropColumn(
                name: "Verantwoordelijke2",
                table: "Categorie");
        }
    }
}
