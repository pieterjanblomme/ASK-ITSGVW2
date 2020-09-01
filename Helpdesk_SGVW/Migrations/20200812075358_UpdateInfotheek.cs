using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class UpdateInfotheek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titel",
                table: "Infotheek",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Infotheek",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titel",
                table: "Infotheek");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Infotheek");
        }
    }
}
