using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class migr7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCharacter_Enemies_EnemyCharacterId",
                table: "ItemCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCharacter_Items_ItemId",
                table: "ItemCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCharacter_PlayableCharacters_PlayableCharacterId",
                table: "ItemCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCharacter",
                table: "ItemCharacter");

            migrationBuilder.DropColumn(
                name: "CurrentHealthPoints",
                table: "PlayableCharacters");

            migrationBuilder.DropColumn(
                name: "CurrentHealthPoints",
                table: "Enemies");

            migrationBuilder.RenameTable(
                name: "ItemCharacter",
                newName: "ItemsEquippedByEachCharacter");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCharacter_PlayableCharacterId",
                table: "ItemsEquippedByEachCharacter",
                newName: "IX_ItemsEquippedByEachCharacter_PlayableCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCharacter_EnemyCharacterId",
                table: "ItemsEquippedByEachCharacter",
                newName: "IX_ItemsEquippedByEachCharacter_EnemyCharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsEquippedByEachCharacter",
                table: "ItemsEquippedByEachCharacter",
                columns: new[] { "ItemId", "PlayableCharacterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsEquippedByEachCharacter_Enemies_EnemyCharacterId",
                table: "ItemsEquippedByEachCharacter",
                column: "EnemyCharacterId",
                principalTable: "Enemies",
                principalColumn: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsEquippedByEachCharacter_Items_ItemId",
                table: "ItemsEquippedByEachCharacter",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsEquippedByEachCharacter_PlayableCharacters_PlayableCharacterId",
                table: "ItemsEquippedByEachCharacter",
                column: "PlayableCharacterId",
                principalTable: "PlayableCharacters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsEquippedByEachCharacter_Enemies_EnemyCharacterId",
                table: "ItemsEquippedByEachCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsEquippedByEachCharacter_Items_ItemId",
                table: "ItemsEquippedByEachCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsEquippedByEachCharacter_PlayableCharacters_PlayableCharacterId",
                table: "ItemsEquippedByEachCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsEquippedByEachCharacter",
                table: "ItemsEquippedByEachCharacter");

            migrationBuilder.RenameTable(
                name: "ItemsEquippedByEachCharacter",
                newName: "ItemCharacter");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsEquippedByEachCharacter_PlayableCharacterId",
                table: "ItemCharacter",
                newName: "IX_ItemCharacter_PlayableCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsEquippedByEachCharacter_EnemyCharacterId",
                table: "ItemCharacter",
                newName: "IX_ItemCharacter_EnemyCharacterId");

            migrationBuilder.AddColumn<int>(
                name: "CurrentHealthPoints",
                table: "PlayableCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHealthPoints",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCharacter",
                table: "ItemCharacter",
                columns: new[] { "ItemId", "PlayableCharacterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCharacter_Enemies_EnemyCharacterId",
                table: "ItemCharacter",
                column: "EnemyCharacterId",
                principalTable: "Enemies",
                principalColumn: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCharacter_Items_ItemId",
                table: "ItemCharacter",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCharacter_PlayableCharacters_PlayableCharacterId",
                table: "ItemCharacter",
                column: "PlayableCharacterId",
                principalTable: "PlayableCharacters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
