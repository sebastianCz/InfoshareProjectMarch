using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class migr6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActions_Statuses_StatusId",
                table: "CharacterActions");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "CharacterActions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActions_Statuses_StatusId",
                table: "CharacterActions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActions_Statuses_StatusId",
                table: "CharacterActions");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "CharacterActions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActions_Statuses_StatusId",
                table: "CharacterActions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
