using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class migr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_Races_RaceId",
                table: "PlayableCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Races",
                table: "Races");

            migrationBuilder.RenameTable(
                name: "Races",
                newName: "PlayableCharacterRaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableCharacterRaces",
                table: "PlayableCharacterRaces",
                column: "PlayableRaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_PlayableCharacterRaces_RaceId",
                table: "PlayableCharacters",
                column: "RaceId",
                principalTable: "PlayableCharacterRaces",
                principalColumn: "PlayableRaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableCharacters_PlayableCharacterRaces_RaceId",
                table: "PlayableCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableCharacterRaces",
                table: "PlayableCharacterRaces");

            migrationBuilder.RenameTable(
                name: "PlayableCharacterRaces",
                newName: "Races");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Races",
                table: "Races",
                column: "PlayableRaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableCharacters_Races_RaceId",
                table: "PlayableCharacters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "PlayableRaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
