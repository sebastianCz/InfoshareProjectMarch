using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class CharacterWithDependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_CharacterAction_ActionToTriggerCharacterActionId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCharacter_Item_ItemId",
                table: "ItemCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_PlayableCharacterClass_CharacterClassID",
                table: "PlayableCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_PlayableRace_RaceId",
                table: "PlayableCharacters");

            migrationBuilder.DropTable(
                name: "PlayableCharacterClass");

            migrationBuilder.DropTable(
                name: "PlayableRace");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "CharacterAction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "CharacterClassID",
                table: "PlayableCharacters",
                newName: "CharacterClassPlayableCharacterClassId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCharacters_CharacterClassID",
                table: "PlayableCharacters",
                newName: "IX_PlayableCharacters_CharacterClassPlayableCharacterClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ActionToTriggerCharacterActionId",
                table: "Items",
                newName: "IX_Items_ActionToTriggerCharacterActionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateTable(
                name: "CharacterActions",
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
                    table.PrimaryKey("PK_CharacterActions", x => x.CharacterActionId);
                    table.ForeignKey(
                        name: "FK_CharacterActions_Enemies_EnemyCharacterId",
                        column: x => x.EnemyCharacterId,
                        principalTable: "Enemies",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_CharacterActions_PlayableCharacters_PlayableCharacterCharacterId",
                        column: x => x.PlayableCharacterCharacterId,
                        principalTable: "PlayableCharacters",
                        principalColumn: "CharacterId");
                });

            migrationBuilder.CreateTable(
                name: "PlayableRaces",
                columns: table => new
                {
                    PlayableCharacterClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayableCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableRaces", x => x.PlayableCharacterClassId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    PlayableRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfSkillsToChoose = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.PlayableRaceId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
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
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Statuses_CharacterActions_CharacterActionId",
                        column: x => x.CharacterActionId,
                        principalTable: "CharacterActions",
                        principalColumn: "CharacterActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_EnemyCharacterId",
                table: "CharacterActions",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_PlayableCharacterCharacterId",
                table: "CharacterActions",
                column: "PlayableCharacterCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CharacterActionId",
                table: "Statuses",
                column: "CharacterActionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCharacter_Items_ItemId",
                table: "ItemCharacter",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CharacterActions_ActionToTriggerCharacterActionId",
                table: "Items",
                column: "ActionToTriggerCharacterActionId",
                principalTable: "CharacterActions",
                principalColumn: "CharacterActionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_PlayableRaces_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters",
                column: "CharacterClassPlayableCharacterClassId",
                principalTable: "PlayableRaces",
                principalColumn: "PlayableCharacterClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_Races_RaceId",
                table: "PlayableCharacters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "PlayableRaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCharacter_Items_ItemId",
                table: "ItemCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_CharacterActions_ActionToTriggerCharacterActionId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_PlayableRaces_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_Races_RaceId",
                table: "PlayableCharacters");

            migrationBuilder.DropTable(
                name: "PlayableRaces");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "CharacterActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameColumn(
                name: "CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters",
                newName: "CharacterClassID");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableCharacters_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters",
                newName: "IX_PlayableCharacters_CharacterClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ActionToTriggerCharacterActionId",
                table: "Item",
                newName: "IX_Item_ActionToTriggerCharacterActionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemId");

            migrationBuilder.CreateTable(
                name: "CharacterAction",
                columns: table => new
                {
                    CharacterActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    AggressiveAction = table.Column<bool>(type: "bit", nullable: false),
                    EnemyCharacterId = table.Column<int>(type: "int", nullable: true),
                    Flat_Dmg = table.Column<int>(type: "int", nullable: false),
                    Hit_Dice_Nr = table.Column<int>(type: "int", nullable: false),
                    InflictsStatus = table.Column<bool>(type: "bit", nullable: false),
                    Max_Dmg = table.Column<int>(type: "int", nullable: false),
                    PlayableCharacterCharacterId = table.Column<int>(type: "int", nullable: true),
                    PossibleTargets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SavingThrowPossible = table.Column<bool>(type: "bit", nullable: false),
                    StatForTest = table.Column<int>(type: "int", nullable: false),
                    UsesLeftBeforeRest = table.Column<int>(type: "int", nullable: false),
                    UsesMax = table.Column<int>(type: "int", nullable: false),
                    UsesMaxBeforeRest = table.Column<int>(type: "int", nullable: false)
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
                    AmountOfSkillsToChoose = table.Column<int>(type: "int", nullable: false),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableRace", x => x.PlayableRaceId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterActionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAction_EnemyCharacterId",
                table: "CharacterAction",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAction_PlayableCharacterCharacterId",
                table: "CharacterAction",
                column: "PlayableCharacterCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_CharacterActionId",
                table: "Status",
                column: "CharacterActionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_CharacterAction_ActionToTriggerCharacterActionId",
                table: "Item",
                column: "ActionToTriggerCharacterActionId",
                principalTable: "CharacterAction",
                principalColumn: "CharacterActionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCharacter_Item_ItemId",
                table: "ItemCharacter",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_PlayableCharacterClass_CharacterClassID",
                table: "PlayableCharacters",
                column: "CharacterClassID",
                principalTable: "PlayableCharacterClass",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_PlayableRace_RaceId",
                table: "PlayableCharacters",
                column: "RaceId",
                principalTable: "PlayableRace",
                principalColumn: "PlayableRaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
