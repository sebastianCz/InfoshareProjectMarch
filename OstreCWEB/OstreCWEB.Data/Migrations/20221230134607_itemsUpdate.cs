using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class itemsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHealthPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentHealthPoints = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    PlayableClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_PlayableCharacterClasses_PlayableClassId",
                        column: x => x.PlayableClassId,
                        principalTable: "PlayableCharacterClasses",
                        principalColumn: "PlayableClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_PlayableCharacterRaces_RaceId",
                        column: x => x.RaceId,
                        principalTable: "PlayableCharacterRaces",
                        principalColumn: "PlayableRaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Users_UserId",
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
                    ActionToTriggerCharacterActionId = table.Column<int>(type: "int", nullable: true),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: true),
                    ArmorType = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actionCharactersRelation", x => new { x.CharacterId, x.CharacterActionId });
                    table.ForeignKey(
                        name: "FK_actionCharactersRelation_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_actionCharactersRelation_CharacterActions_CharacterActionId",
                        column: x => x.CharacterActionId,
                        principalTable: "CharacterActions",
                        principalColumn: "CharacterActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCharactersRelation",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    IsEquipped = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCharactersRelation", x => new { x.ItemId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_ItemsCharactersRelation_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsCharactersRelation_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actionCharactersRelation_CharacterActionId",
                table: "actionCharactersRelation",
                column: "CharacterActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlayableClassId",
                table: "Character",
                column: "PlayableClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_StatusId",
                table: "CharacterActions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ActionToTriggerCharacterActionId",
                table: "Items",
                column: "ActionToTriggerCharacterActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCharactersRelation_CharacterId",
                table: "ItemsCharactersRelation",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actionCharactersRelation");

            migrationBuilder.DropTable(
                name: "ItemsCharactersRelation");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PlayableCharacterClasses");

            migrationBuilder.DropTable(
                name: "PlayableCharacterRaces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CharacterActions");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
