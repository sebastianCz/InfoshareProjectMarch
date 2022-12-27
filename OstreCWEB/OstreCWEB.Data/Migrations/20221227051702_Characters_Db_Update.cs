using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class Characters_Db_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CombatId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHealthPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentHealthPoints = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "PlayableCharacterClass",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayableCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCharacterClass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayableRace",
                columns: table => new
                {
                    PlayableRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfSkillsToChoose = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableRace", x => x.PlayableRaceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveStoryId = table.Column<int>(type: "int", nullable: false),
                    StoriesCompletedTotal = table.Column<int>(type: "int", nullable: false),
                    DamageDealt = table.Column<int>(type: "int", nullable: false),
                    DamageReceived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayableCharacters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    CharacterClassID = table.Column<int>(type: "int", nullable: false),
                    PlayableClassId = table.Column<int>(type: "int", nullable: false),
                    CombatId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHealthPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentHealthPoints = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCharacters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_PlayableCharacters_PlayableCharacterClass_CharacterClassID",
                        column: x => x.CharacterClassID,
                        principalTable: "PlayableCharacterClass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCharacters_PlayableRace_RaceId",
                        column: x => x.RaceId,
                        principalTable: "PlayableRace",
                        principalColumn: "PlayableRaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCharacters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAction",
                columns: table => new
                {
                    CharacterActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    SavingThrowPossible = table.Column<bool>(type: "bit", nullable: false),
                    Max_Dmg = table.Column<int>(type: "int", nullable: false),
                    Flat_Dmg = table.Column<int>(type: "int", nullable: false),
                    Hit_Dice_Nr = table.Column<int>(type: "int", nullable: false),
                    PossibleTargets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InflictsStatus = table.Column<bool>(type: "bit", nullable: false),
                    StatForTest = table.Column<int>(type: "int", nullable: false),
                    UsesMaxBeforeRest = table.Column<int>(type: "int", nullable: false),
                    UsesLeftBeforeRest = table.Column<int>(type: "int", nullable: false),
                    UsesMax = table.Column<int>(type: "int", nullable: false),
                    AggressiveAction = table.Column<bool>(type: "bit", nullable: false),
                    EnemyCharacterId = table.Column<int>(type: "int", nullable: true),
                    PlayableCharacterCharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAction", x => x.CharacterActionId);
                    table.ForeignKey(
                        name: "FK_CharacterAction_Enemies_EnemyCharacterId",
                        column: x => x.EnemyCharacterId,
                        principalTable: "Enemies",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_CharacterAction_PlayableCharacters_PlayableCharacterCharacterId",
                        column: x => x.PlayableCharacterCharacterId,
                        principalTable: "PlayableCharacters",
                        principalColumn: "CharacterId");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    ArmorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionToTriggerCharacterActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_CharacterAction_ActionToTriggerCharacterActionId",
                        column: x => x.ActionToTriggerCharacterActionId,
                        principalTable: "CharacterAction",
                        principalColumn: "CharacterActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterActionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Status_CharacterAction_CharacterActionId",
                        column: x => x.CharacterActionId,
                        principalTable: "CharacterAction",
                        principalColumn: "CharacterActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCharacter",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    PlayableCharacterId = table.Column<int>(type: "int", nullable: false),
                    EnemyCharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCharacter", x => new { x.ItemId, x.PlayableCharacterId });
                    table.ForeignKey(
                        name: "FK_ItemCharacter_Enemies_EnemyCharacterId",
                        column: x => x.EnemyCharacterId,
                        principalTable: "Enemies",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_ItemCharacter_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCharacter_PlayableCharacters_PlayableCharacterId",
                        column: x => x.PlayableCharacterId,
                        principalTable: "PlayableCharacters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAction_EnemyCharacterId",
                table: "CharacterAction",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAction_PlayableCharacterCharacterId",
                table: "CharacterAction",
                column: "PlayableCharacterCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ActionToTriggerCharacterActionId",
                table: "Item",
                column: "ActionToTriggerCharacterActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCharacter_EnemyCharacterId",
                table: "ItemCharacter",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCharacter_PlayableCharacterId",
                table: "ItemCharacter",
                column: "PlayableCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCharacters_CharacterClassID",
                table: "PlayableCharacters",
                column: "CharacterClassID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCharacters_RaceId",
                table: "PlayableCharacters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCharacters_UserId",
                table: "PlayableCharacters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_CharacterActionId",
                table: "Status",
                column: "CharacterActionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCharacter");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "CharacterAction");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "PlayableCharacters");

            migrationBuilder.DropTable(
                name: "PlayableCharacterClass");

            migrationBuilder.DropTable(
                name: "PlayableRace");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
