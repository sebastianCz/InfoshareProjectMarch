using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class NullableEnemyInParagraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemyInParagraphs_Character_EnemyId",
                table: "EnemyInParagraphs");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyId",
                table: "EnemyInParagraphs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyInParagraphs_Character_EnemyId",
                table: "EnemyInParagraphs",
                column: "EnemyId",
                principalTable: "Character",
                principalColumn: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemyInParagraphs_Character_EnemyId",
                table: "EnemyInParagraphs");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyId",
                table: "EnemyInParagraphs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyInParagraphs_Character_EnemyId",
                table: "EnemyInParagraphs",
                column: "EnemyId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
