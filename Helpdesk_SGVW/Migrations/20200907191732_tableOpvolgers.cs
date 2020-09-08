using Microsoft.EntityFrameworkCore.Migrations;

//namespace Helpdesk_SGVW.Migrations
//{
//    public partial class tableOpvolgers : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Opvolgers");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Opvolgers",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Displaynaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Familienaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Opvolgers", x => x.Id);
//                });
//        }
//    }
//}
