using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActions_Enemies_EnemyCharacterId",
                table: "CharacterActions");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActions_PlayableCharacters_PlayableCharacterCharacterId",
                table: "CharacterActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_PlayableRaces_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters");

            migrationBuilder.DropIndex(
                name: "IX_CharacterActions_EnemyCharacterId",
                table: "CharacterActions");

            migrationBuilder.DropIndex(
                name: "IX_CharacterActions_PlayableCharacterCharacterId",
                table: "CharacterActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableRaces",
                table: "PlayableRaces");

            migrationBuilder.DropColumn(
                name: "EnemyCharacterId",
                table: "CharacterActions");

            migrationBuilder.DropColumn(
                name: "PlayableCharacterCharacterId",
                table: "CharacterActions");

            migrationBuilder.RenameTable(
                name: "PlayableRaces",
                newName: "PlayableCharacterClasses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableCharacterClasses",
                table: "PlayableCharacterClasses",
                column: "PlayableCharacterClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_PlayableCharacterClasses_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters",
                column: "CharacterClassPlayableCharacterClassId",
                principalTable: "PlayableCharacterClasses",
                principalColumn: "PlayableCharacterClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_PlayableCharacterClasses_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableCharacterClasses",
                table: "PlayableCharacterClasses");

            migrationBuilder.RenameTable(
                name: "PlayableCharacterClasses",
                newName: "PlayableRaces");

            migrationBuilder.AddColumn<int>(
                name: "EnemyCharacterId",
                table: "CharacterActions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayableCharacterCharacterId",
                table: "CharacterActions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableRaces",
                table: "PlayableRaces",
                column: "PlayableCharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_EnemyCharacterId",
                table: "CharacterActions",
                column: "EnemyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_PlayableCharacterCharacterId",
                table: "CharacterActions",
                column: "PlayableCharacterCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActions_Enemies_EnemyCharacterId",
                table: "CharacterActions",
                column: "EnemyCharacterId",
                principalTable: "Enemies",
                principalColumn: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActions_PlayableCharacters_PlayableCharacterCharacterId",
                table: "CharacterActions",
                column: "PlayableCharacterCharacterId",
                principalTable: "PlayableCharacters",
                principalColumn: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_PlayableRaces_CharacterClassPlayableCharacterClassId",
                table: "PlayableCharacters",
                column: "CharacterClassPlayableCharacterClassId",
                principalTable: "PlayableRaces",
                principalColumn: "PlayableCharacterClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
