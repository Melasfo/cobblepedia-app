using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTrial11.Data.Migrations
{
    public partial class Cobblemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    SpecialAttack = table.Column<int>(type: "int", nullable: false),
                    SpecialDefense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    TotalStats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cobblemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalDexNum = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abilities = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobblemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EggMove",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovePower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveAccuracy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EggMove", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelUpMove",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveLevel = table.Column<int>(type: "int", nullable: false),
                    MoveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovePower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveAccuracy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelUpMove", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TMMove",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TMNumber = table.Column<int>(type: "int", nullable: false),
                    MoveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovePower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveAccuracy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMMove", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CobblemonBaseStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobblemonId = table.Column<int>(type: "int", nullable: false),
                    BaseStatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobblemonBaseStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobblemonBaseStats_BaseStat_BaseStatId",
                        column: x => x.BaseStatId,
                        principalTable: "BaseStat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobblemonBaseStats_Cobblemon_CobblemonId",
                        column: x => x.CobblemonId,
                        principalTable: "Cobblemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobblemonEggMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobblemonId = table.Column<int>(type: "int", nullable: false),
                    EggMoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobblemonEggMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobblemonEggMoves_Cobblemon_CobblemonId",
                        column: x => x.CobblemonId,
                        principalTable: "Cobblemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobblemonEggMoves_EggMove_EggMoveId",
                        column: x => x.EggMoveId,
                        principalTable: "EggMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobblemonLevelUpMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobblemonId = table.Column<int>(type: "int", nullable: false),
                    LevelUpMoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobblemonLevelUpMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobblemonLevelUpMoves_Cobblemon_CobblemonId",
                        column: x => x.CobblemonId,
                        principalTable: "Cobblemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobblemonLevelUpMoves_LevelUpMove_LevelUpMoveId",
                        column: x => x.LevelUpMoveId,
                        principalTable: "LevelUpMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobblemonTMMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobblemonId = table.Column<int>(type: "int", nullable: false),
                    TMMoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobblemonTMMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobblemonTMMoves_Cobblemon_CobblemonId",
                        column: x => x.CobblemonId,
                        principalTable: "Cobblemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobblemonTMMoves_TMMove_TMMoveId",
                        column: x => x.TMMoveId,
                        principalTable: "TMMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonBaseStats_BaseStatId",
                table: "CobblemonBaseStats",
                column: "BaseStatId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonBaseStats_CobblemonId",
                table: "CobblemonBaseStats",
                column: "CobblemonId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonEggMoves_CobblemonId",
                table: "CobblemonEggMoves",
                column: "CobblemonId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonEggMoves_EggMoveId",
                table: "CobblemonEggMoves",
                column: "EggMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonLevelUpMoves_CobblemonId",
                table: "CobblemonLevelUpMoves",
                column: "CobblemonId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonLevelUpMoves_LevelUpMoveId",
                table: "CobblemonLevelUpMoves",
                column: "LevelUpMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonTMMoves_CobblemonId",
                table: "CobblemonTMMoves",
                column: "CobblemonId");

            migrationBuilder.CreateIndex(
                name: "IX_CobblemonTMMoves_TMMoveId",
                table: "CobblemonTMMoves",
                column: "TMMoveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobblemonBaseStats");

            migrationBuilder.DropTable(
                name: "CobblemonEggMoves");

            migrationBuilder.DropTable(
                name: "CobblemonLevelUpMoves");

            migrationBuilder.DropTable(
                name: "CobblemonTMMoves");

            migrationBuilder.DropTable(
                name: "BaseStat");

            migrationBuilder.DropTable(
                name: "EggMove");

            migrationBuilder.DropTable(
                name: "LevelUpMove");

            migrationBuilder.DropTable(
                name: "Cobblemon");

            migrationBuilder.DropTable(
                name: "TMMove");
        }
    }
}
