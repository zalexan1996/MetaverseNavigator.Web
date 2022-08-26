using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MN.Data.Migrations
{
    public partial class LinkedConfidantWithGameCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameCharacterId",
                table: "Confidant",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.AddForeignKey(
                name: "FK_Confidant_GameCharacter_GameCharacterId",
                table: "Confidant",
                column: "GameCharacterId",
                principalTable: "GameCharacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Confidant_GameCharacter_GameCharacterId",
                table: "Confidant");


            migrationBuilder.DropColumn(
                name: "GameCharacterId",
                table: "Confidant");
        }
    }
}
