using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSports.web.Migrations
{
    public partial class updatedPrize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentPrizes");

            migrationBuilder.DropColumn(
                name: "PrizePercentage",
                table: "Prizes");

            migrationBuilder.AddColumn<int>(
                name: "PrizeId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrizeAmount",
                table: "Prizes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceName",
                table: "Prizes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceName2",
                table: "Prizes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceName3",
                table: "Prizes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrizeAmount2",
                table: "Prizes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrizeAmount3",
                table: "Prizes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrizeAmount4To10",
                table: "Prizes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrizeName",
                table: "Prizes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_PrizeId",
                table: "Tournaments",
                column: "PrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Prizes_PrizeId",
                table: "Tournaments",
                column: "PrizeId",
                principalTable: "Prizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Prizes_PrizeId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_PrizeId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "PrizeId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "PlaceName2",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "PlaceName3",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "PrizeAmount2",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "PrizeAmount3",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "PrizeAmount4To10",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "PrizeName",
                table: "Prizes");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrizeAmount",
                table: "Prizes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceName",
                table: "Prizes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrizePercentage",
                table: "Prizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TournamentPrizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrizeId = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPrizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentPrizes_Prizes_PrizeId",
                        column: x => x.PrizeId,
                        principalTable: "Prizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentPrizes_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPrizes_PrizeId",
                table: "TournamentPrizes",
                column: "PrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPrizes_TournamentId",
                table: "TournamentPrizes",
                column: "TournamentId");
        }
    }
}
