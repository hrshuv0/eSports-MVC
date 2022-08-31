using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSports.web.Migrations
{
    public partial class addedTournamentCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentCategoryId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TournamentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentCategoryId",
                table: "Tournaments",
                column: "TournamentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentCategories_TournamentCategoryId",
                table: "Tournaments",
                column: "TournamentCategoryId",
                principalTable: "TournamentCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentCategories_TournamentCategoryId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "TournamentCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TournamentCategoryId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TournamentCategoryId",
                table: "Tournaments");
        }
    }
}
