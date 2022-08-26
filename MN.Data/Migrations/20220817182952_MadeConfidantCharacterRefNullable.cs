using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MN.Data.Migrations
{
    public partial class MadeConfidantCharacterRefNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Confidant_GameCharacter_GameCharacterId",
                table: "Confidant");


            migrationBuilder.AlterColumn<int>(
                name: "GameCharacterId",
                table: "Confidant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Confidant_GameCharacterId",
                table: "Confidant",
                column: "GameCharacterId",
                unique: true,
                filter: "[GameCharacterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Confidant_GameCharacter_GameCharacterId",
                table: "Confidant",
                column: "GameCharacterId",
                principalTable: "GameCharacter",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Confidant_GameCharacter_GameCharacterId",
                table: "Confidant");

            migrationBuilder.AlterColumn<int>(
                name: "GameCharacterId",
                table: "Confidant",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Confidant_GameCharacterId",
                table: "Confidant",
                column: "GameCharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Confidant_GameCharacter_GameCharacterId",
                table: "Confidant",
                column: "GameCharacterId",
                principalTable: "GameCharacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
