using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSports.web.Migrations
{
    public partial class addedDateTimeTournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Tournaments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Tournaments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalMatch",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TotalMatch",
                table: "Tournaments");
        }
    }
}
