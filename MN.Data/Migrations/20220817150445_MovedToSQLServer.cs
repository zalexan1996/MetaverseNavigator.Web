using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MN.Data.Migrations
{
    public partial class MovedToSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confidant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confidant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeleeWeaponType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeWeaponType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangedWeaponType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangedWeaponType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfidantBenefit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankUnlocked = table.Column<int>(type: "int", nullable: false),
                    AbilityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfidantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfidantBenefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfidantBenefit_Confidant_ConfidantId",
                        column: x => x.ConfidantId,
                        principalTable: "Confidant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfidantResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfidantId = table.Column<int>(type: "int", nullable: false),
                    ResponseOrder = table.Column<int>(type: "int", nullable: false),
                    ResponseText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BoostAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfidantResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfidantResponses_Confidant_ConfidantId",
                        column: x => x.ConfidantId,
                        principalTable: "Confidant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfidantId = table.Column<int>(type: "int", nullable: false),
                    StartingLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Confidant_ConfidantId",
                        column: x => x.ConfidantId,
                        principalTable: "Confidant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfidantGift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfidantId = table.Column<int>(type: "int", nullable: false),
                    GameItemId = table.Column<int>(type: "int", nullable: false),
                    GiftScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfidantGift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfidantGift_Confidant_ConfidantId",
                        column: x => x.ConfidantId,
                        principalTable: "Confidant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfidantGift_GameItem_GameItemId",
                        column: x => x.GameItemId,
                        principalTable: "GameItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeleeWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeleeWeaponTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeWeapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeleeWeapon_MeleeWeaponType_MeleeWeaponTypeId",
                        column: x => x.MeleeWeaponTypeId,
                        principalTable: "MeleeWeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RangedWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangedWeaponTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangedWeapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangedWeapon_RangedWeaponType_RangedWeaponTypeId",
                        column: x => x.RangedWeaponTypeId,
                        principalTable: "RangedWeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameCharacterId = table.Column<int>(type: "int", nullable: false),
                    ConfidantId = table.Column<int>(type: "int", nullable: false),
                    Codename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BasePersonaId = table.Column<int>(type: "int", nullable: false),
                    AwakenedPersonaId = table.Column<int>(type: "int", nullable: false),
                    MeleeWeaponTypeId = table.Column<int>(type: "int", nullable: false),
                    RangedWeaponTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleCharacter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Confidant_ConfidantId",
                        column: x => x.ConfidantId,
                        principalTable: "Confidant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCharacter_GameCharacter_GameCharacterId",
                        column: x => x.GameCharacterId,
                        principalTable: "GameCharacter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacter_MeleeWeaponType_MeleeWeaponTypeId",
                        column: x => x.MeleeWeaponTypeId,
                        principalTable: "MeleeWeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Persona_AwakenedPersonaId",
                        column: x => x.AwakenedPersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Persona_BasePersonaId",
                        column: x => x.BasePersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacter_RangedWeaponType_RangedWeaponTypeId",
                        column: x => x.RangedWeaponTypeId,
                        principalTable: "RangedWeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_AwakenedPersonaId",
                table: "BattleCharacter",
                column: "AwakenedPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_BasePersonaId",
                table: "BattleCharacter",
                column: "BasePersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_ConfidantId",
                table: "BattleCharacter",
                column: "ConfidantId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_GameCharacterId",
                table: "BattleCharacter",
                column: "GameCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_MeleeWeaponTypeId",
                table: "BattleCharacter",
                column: "MeleeWeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_RangedWeaponTypeId",
                table: "BattleCharacter",
                column: "RangedWeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidantBenefit_ConfidantId",
                table: "ConfidantBenefit",
                column: "ConfidantId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidantGift_ConfidantId",
                table: "ConfidantGift",
                column: "ConfidantId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidantGift_GameItemId",
                table: "ConfidantGift",
                column: "GameItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidantResponses_ConfidantId",
                table: "ConfidantResponses",
                column: "ConfidantId");

            migrationBuilder.CreateIndex(
                name: "IX_MeleeWeapon_MeleeWeaponTypeId",
                table: "MeleeWeapon",
                column: "MeleeWeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ConfidantId",
                table: "Persona",
                column: "ConfidantId");

            migrationBuilder.CreateIndex(
                name: "IX_RangedWeapon_RangedWeaponTypeId",
                table: "RangedWeapon",
                column: "RangedWeaponTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleCharacter");

            migrationBuilder.DropTable(
                name: "ConfidantBenefit");

            migrationBuilder.DropTable(
                name: "ConfidantGift");

            migrationBuilder.DropTable(
                name: "ConfidantResponses");

            migrationBuilder.DropTable(
                name: "MeleeWeapon");

            migrationBuilder.DropTable(
                name: "RangedWeapon");

            migrationBuilder.DropTable(
                name: "GameCharacter");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "GameItem");

            migrationBuilder.DropTable(
                name: "MeleeWeaponType");

            migrationBuilder.DropTable(
                name: "RangedWeaponType");

            migrationBuilder.DropTable(
                name: "Confidant");
        }
    }
}
