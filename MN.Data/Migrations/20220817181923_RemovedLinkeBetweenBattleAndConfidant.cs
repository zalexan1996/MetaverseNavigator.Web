using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MN.Data.Migrations
{
    public partial class RemovedLinkeBetweenBattleAndConfidant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleCharacter_Confidant_ConfidantId",
                table: "BattleCharacter");

            migrationBuilder.DropIndex(
                name: "IX_BattleCharacter_ConfidantId",
                table: "BattleCharacter");

            migrationBuilder.DropColumn(
                name: "ConfidantId",
                table: "BattleCharacter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfidantId",
                table: "BattleCharacter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_ConfidantId",
                table: "BattleCharacter",
                column: "ConfidantId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacter_Confidant_ConfidantId",
                table: "BattleCharacter",
                column: "ConfidantId",
                principalTable: "Confidant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
