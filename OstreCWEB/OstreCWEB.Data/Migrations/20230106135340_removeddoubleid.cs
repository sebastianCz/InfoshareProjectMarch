using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class removeddoubleid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_UserParagraphs_UserParagraphId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserParagraphId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserParagraphId1",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "UserParagraphId",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserParagraphId",
                table: "Character",
                column: "UserParagraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_UserParagraphs_UserParagraphId",
                table: "Character",
                column: "UserParagraphId",
                principalTable: "UserParagraphs",
                principalColumn: "UserParagraphId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_UserParagraphs_UserParagraphId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserParagraphId",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "UserParagraphId",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserParagraphId1",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserParagraphId1",
                table: "Character",
                column: "UserParagraphId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_UserParagraphs_UserParagraphId1",
                table: "Character",
                column: "UserParagraphId1",
                principalTable: "UserParagraphs",
                principalColumn: "UserParagraphId");
        }
    }
}
