using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTrial11.Data.Migrations
{
    public partial class CanEvolve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanEvolve",
                table: "Cobblemon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EvolutionMethod",
                table: "Cobblemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanEvolve",
                table: "Cobblemon");

            migrationBuilder.DropColumn(
                name: "EvolutionMethod",
                table: "Cobblemon");
        }
    }
}
