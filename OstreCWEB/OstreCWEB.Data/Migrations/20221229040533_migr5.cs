using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_CharacterActions_CharacterActionId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_CharacterActionId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CharacterActionId",
                table: "Statuses");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CharacterActions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterActions_StatusId",
                table: "CharacterActions",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActions_Statuses_StatusId",
                table: "CharacterActions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActions_Statuses_StatusId",
                table: "CharacterActions");

            migrationBuilder.DropIndex(
                name: "IX_CharacterActions_StatusId",
                table: "CharacterActions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CharacterActions");

            migrationBuilder.AddColumn<int>(
                name: "CharacterActionId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CharacterActionId",
                table: "Statuses",
                column: "CharacterActionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_CharacterActions_CharacterActionId",
                table: "Statuses",
                column: "CharacterActionId",
                principalTable: "CharacterActions",
                principalColumn: "CharacterActionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
