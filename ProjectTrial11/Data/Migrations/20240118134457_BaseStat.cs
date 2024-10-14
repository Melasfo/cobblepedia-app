using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTrial11.Data.Migrations
{
    public partial class BaseStat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CobblemonStatsName",
                table: "BaseStat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CobblemonStatsName",
                table: "BaseStat");
        }
    }
}
