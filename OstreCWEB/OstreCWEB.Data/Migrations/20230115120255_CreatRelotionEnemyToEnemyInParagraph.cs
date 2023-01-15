using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class CreatRelotionEnemyToEnemyInParagraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnemyName",
                table: "EnemyInParagraphs");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyInParagraphs_EnemyId",
                table: "EnemyInParagraphs",
                column: "EnemyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyInParagraphs_Character_EnemyId",
                table: "EnemyInParagraphs",
                column: "EnemyId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemyInParagraphs_Character_EnemyId",
                table: "EnemyInParagraphs");

            migrationBuilder.DropIndex(
                name: "IX_EnemyInParagraphs_EnemyId",
                table: "EnemyInParagraphs");

            migrationBuilder.AddColumn<string>(
                name: "EnemyName",
                table: "EnemyInParagraphs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
