using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class StatusCharacterActionMigration : Migration
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
                    Level = table.Column<int>(type: "int", nullable: false),
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
                name: "PlayableCharacterClasses",
                columns: table => new
                {
                    PlayableClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntelligenceBonus = table.Column<int>(type: "int", nullable: false),
                    StrengthBonus = table.Column<int>(type: "int", nullable: false),
                    WisdomBonus = table.Column<int>(type: "int", nullable: false),
                    DexterityBonus = table.Column<int>(type: "int", nullable: false),
                    ConstitutionBonus = table.Column<int>(type: "int", nullable: false),
                    CharismaBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCharacterClasses", x => x.PlayableClassId);
                });

            migrationBuilder.CreateTable(
                name: "PlayableCharacterRaces",
                columns: table => new
                {
                    PlayableRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfSkillsToChoose = table.Column<int>(type: "int", nullable: false),
                    IntelligenceBonus = table.Column<int>(type: "int", nullable: false),
                    StrengthBonus = table.Column<int>(type: "int", nullable: false),
                    WisdomBonus = table.Column<int>(type: "int", nullable: false),
                    DexterityBonus = table.Column<int>(type: "int", nullable: false),
                    ConstitutionBonus = table.Column<int>(type: "int", nullable: false),
                    CharismaBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCharacterRaces", x => x.PlayableRaceId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
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
                name: "CharacterActions",
                columns: table => new
                {
                    CharacterActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
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
                    AggressiveAction = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterActions", x => x.CharacterActionId);
                    table.ForeignKey(
                        name: "FK_CharacterActions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "PlayableCharacters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    PlayableClassId = table.Column<int>(type: "int", nullable: false),
                    CombatId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHealthPoints = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_PlayableCharacters_PlayableCharacterClasses_PlayableClassId",
                        column: x => x.PlayableClassId,
                        principalTable: "PlayableCharacterClasses",
                        principalColumn: "PlayableClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCharacters_PlayableCharacterRaces_RaceId",
                        column: x => x.RaceId,
                        principalTable: "PlayableCharacterRaces",
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
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: true),
                    ArmorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionToTriggerCharacterActionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_CharacterActions_ActionToTriggerCharacterActionId",
                        column: x => x.ActionToTriggerCharacterActionId,
                        principalTable: "CharacterActions",
                        principalColumn: "CharacterActionId");
                });

            migrationBuilder.CreateTable(
                name: "actionCharactersRelation",
                columns: table => new
                {
                    CharacterActionId = table.Column<int>(type: "int", nullable: false),
                    PlayableCharacterId = table.Column<int>(type: "int", nullable: false),
                    EnemyCharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actionCharactersRelation", x => new { x.CharacterActionId, x.PlayableCharacterId });
                    table.ForeignKey(
                        name: "FK_actionCharactersRelation_CharacterActions_CharacterActionId",
                        column: x => x.CharacterActionId,
                        principalTable: "CharacterActions",
                        principalColumn: "CharacterActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_actionCharactersRelation_Enemies_EnemyCharacterId",
                        column: x => x.EnemyCharacterId,
                        principalTable: "Enemies",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_actionCharactersRelation_PlayableCharacters_PlayableCharacterId",
                        column: x => x.PlayableCharacterId,
                        principalTable: "PlayableCharacters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCharactersRelation",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    PlayableCharacterId = table.Column<int>(type: "int", nullable: false),
                    EnemyCharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCharactersRelation", x => new { x.ItemId, x.PlayableCharacterId });
                    table.ForeignKey(
                        name: "FK_ItemsCharactersRelation_Enemies_EnemyCharacterId",
                        column: x => x.EnemyCharacterId,
                        principalTable: "Enemies",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_ItemsCharactersRelation_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsCharactersRelation_PlayableCharacters_PlayableCharacterId",
                        column: x => x.PlayableCharacterId,
                        principalTable: "PlayableCharacters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actionCharactersRelation_EnemyCharacterId",
                table: "actionCharactersRelation",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_actionCharactersRelation_PlayableCharacterId",
                table: "actionCharactersRelation",
                column: "PlayableCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_StatusId",
                table: "CharacterActions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ActionToTriggerCharacterActionId",
                table: "Items",
                column: "ActionToTriggerCharacterActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCharactersRelation_EnemyCharacterId",
                table: "ItemsCharactersRelation",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCharactersRelation_PlayableCharacterId",
                table: "ItemsCharactersRelation",
                column: "PlayableCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCharacters_PlayableClassId",
                table: "PlayableCharacters",
                column: "PlayableClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCharacters_RaceId",
                table: "PlayableCharacters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCharacters_UserId",
                table: "PlayableCharacters",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actionCharactersRelation");

            migrationBuilder.DropTable(
                name: "ItemsCharactersRelation");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PlayableCharacters");

            migrationBuilder.DropTable(
                name: "CharacterActions");

            migrationBuilder.DropTable(
                name: "PlayableCharacterClasses");

            migrationBuilder.DropTable(
                name: "PlayableCharacterRaces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
