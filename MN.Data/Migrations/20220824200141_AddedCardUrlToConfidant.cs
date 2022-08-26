using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MN.Data.Migrations
{
    public partial class AddedCardUrlToConfidant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardUrl",
                table: "Confidant",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardUrl",
                table: "Confidant");
        }
    }
}
