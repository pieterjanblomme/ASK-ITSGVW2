using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class logo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "School",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo",
                table: "School");
        }
    }
}
