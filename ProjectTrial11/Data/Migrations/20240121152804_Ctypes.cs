using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTrial11.Data.Migrations
{
    public partial class Ctypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CobblemonCType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobblemonId = table.Column<int>(type: "int", nullable: false),
                    CTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobblemonCType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobblemonCType_Cobblemon_CobblemonId",
                        column: x => x.CobblemonId,
                        principalTable: "Cobblemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobblemonCType_Type_CTypeId",
                        column: x => x.CTypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonCType_CobblemonId",
                table: "CobblemonCType",
                column: "CobblemonId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonCType_CTypeId",
                table: "CobblemonCType",
                column: "CTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobblemonCType");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
