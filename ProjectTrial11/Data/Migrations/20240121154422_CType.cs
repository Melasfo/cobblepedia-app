using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTrial11.Data.Migrations
{
    public partial class CType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobblemonCType_Cobblemon_CobblemonId",
                table: "CobblemonCType");

            migrationBuilder.DropForeignKey(
                name: "FK_CobblemonCType_Type_CTypeId",
                table: "CobblemonCType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CobblemonCType",
                table: "CobblemonCType");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "CType");

            migrationBuilder.RenameTable(
                name: "CobblemonCType",
                newName: "CobblemonCTypes");

            migrationBuilder.RenameIndex(
                name: "IX_CobblemonCType_CTypeId",
                table: "CobblemonCTypes",
                newName: "IX_CobblemonCTypes_CTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CobblemonCType_CobblemonId",
                table: "CobblemonCTypes",
                newName: "IX_CobblemonCTypes_CobblemonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CType",
                table: "CType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CobblemonCTypes",
                table: "CobblemonCTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CobblemonCTypes_Cobblemon_CobblemonId",
                table: "CobblemonCTypes",
                column: "CobblemonId",
                principalTable: "Cobblemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CobblemonCTypes_CType_CTypeId",
                table: "CobblemonCTypes",
                column: "CTypeId",
                principalTable: "CType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobblemonCTypes_Cobblemon_CobblemonId",
                table: "CobblemonCTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CobblemonCTypes_CType_CTypeId",
                table: "CobblemonCTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CType",
                table: "CType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CobblemonCTypes",
                table: "CobblemonCTypes");

            migrationBuilder.RenameTable(
                name: "CType",
                newName: "Type");

            migrationBuilder.RenameTable(
                name: "CobblemonCTypes",
                newName: "CobblemonCType");

            migrationBuilder.RenameIndex(
                name: "IX_CobblemonCTypes_CTypeId",
                table: "CobblemonCType",
                newName: "IX_CobblemonCType_CTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CobblemonCTypes_CobblemonId",
                table: "CobblemonCType",
                newName: "IX_CobblemonCType_CobblemonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CobblemonCType",
                table: "CobblemonCType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CobblemonCType_Cobblemon_CobblemonId",
                table: "CobblemonCType",
                column: "CobblemonId",
                principalTable: "Cobblemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CobblemonCType_Type_CTypeId",
                table: "CobblemonCType",
                column: "CTypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
