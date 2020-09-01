using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk_SGVW.Migrations
{
    public partial class ToevoegenInfotheek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infotheek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(nullable: true),
                    CategorieId = table.Column<int>(nullable: false),
                    SubCategorieId = table.Column<int>(nullable: false),
                    Tag1 = table.Column<string>(nullable: true),
                    Tag2 = table.Column<string>(nullable: true),
                    Tag3 = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infotheek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infotheek_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Infotheek_SubCategorie_SubCategorieId",
                        column: x => x.SubCategorieId,
                        principalTable: "SubCategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Infotheek_CategorieId",
                table: "Infotheek",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Infotheek_SubCategorieId",
                table: "Infotheek",
                column: "SubCategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infotheek");
        }
    }
}
