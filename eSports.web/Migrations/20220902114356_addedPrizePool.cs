using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSports.web.Migrations
{
    public partial class addedPrizePool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrizePool",
                table: "Tournaments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrizePool",
                table: "Tournaments");
        }
    }
}
