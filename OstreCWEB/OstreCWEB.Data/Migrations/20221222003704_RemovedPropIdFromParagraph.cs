using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class RemovedPropIdFromParagraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_DialogProps_DialogPropId",
                table: "Paragraphs");

            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_FightProps_FightPropId",
                table: "Paragraphs");

            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_ShopkeeperProps_ShopkeeperPropId",
                table: "Paragraphs");

            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_TestProps_TestPropId",
                table: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Paragraphs_DialogPropId",
                table: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Paragraphs_FightPropId",
                table: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Paragraphs_ShopkeeperPropId",
                table: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Paragraphs_TestPropId",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "DialogPropId",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "FightPropId",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "ShopkeeperPropId",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "TestPropId",
                table: "Paragraphs");

            migrationBuilder.CreateIndex(
                name: "IX_TestProps_ParagraphId",
                table: "TestProps",
                column: "ParagraphId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopkeeperProps_ParagraphId",
                table: "ShopkeeperProps",
                column: "ParagraphId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FightProps_ParagraphId",
                table: "FightProps",
                column: "ParagraphId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DialogProps_ParagraphId",
                table: "DialogProps",
                column: "ParagraphId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DialogProps_Paragraphs_ParagraphId",
                table: "DialogProps",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightProps_Paragraphs_ParagraphId",
                table: "FightProps",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopkeeperProps_Paragraphs_ParagraphId",
                table: "ShopkeeperProps",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProps_Paragraphs_ParagraphId",
                table: "TestProps",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogProps_Paragraphs_ParagraphId",
                table: "DialogProps");

            migrationBuilder.DropForeignKey(
                name: "FK_FightProps_Paragraphs_ParagraphId",
                table: "FightProps");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopkeeperProps_Paragraphs_ParagraphId",
                table: "ShopkeeperProps");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProps_Paragraphs_ParagraphId",
                table: "TestProps");

            migrationBuilder.DropIndex(
                name: "IX_TestProps_ParagraphId",
                table: "TestProps");

            migrationBuilder.DropIndex(
                name: "IX_ShopkeeperProps_ParagraphId",
                table: "ShopkeeperProps");

            migrationBuilder.DropIndex(
                name: "IX_FightProps_ParagraphId",
                table: "FightProps");

            migrationBuilder.DropIndex(
                name: "IX_DialogProps_ParagraphId",
                table: "DialogProps");

            migrationBuilder.AddColumn<int>(
                name: "DialogPropId",
                table: "Paragraphs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FightPropId",
                table: "Paragraphs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopkeeperPropId",
                table: "Paragraphs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestPropId",
                table: "Paragraphs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_DialogPropId",
                table: "Paragraphs",
                column: "DialogPropId",
                unique: true,
                filter: "[DialogPropId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_FightPropId",
                table: "Paragraphs",
                column: "FightPropId",
                unique: true,
                filter: "[FightPropId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_ShopkeeperPropId",
                table: "Paragraphs",
                column: "ShopkeeperPropId",
                unique: true,
                filter: "[ShopkeeperPropId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_TestPropId",
                table: "Paragraphs",
                column: "TestPropId",
                unique: true,
                filter: "[TestPropId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_DialogProps_DialogPropId",
                table: "Paragraphs",
                column: "DialogPropId",
                principalTable: "DialogProps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_FightProps_FightPropId",
                table: "Paragraphs",
                column: "FightPropId",
                principalTable: "FightProps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_ShopkeeperProps_ShopkeeperPropId",
                table: "Paragraphs",
                column: "ShopkeeperPropId",
                principalTable: "ShopkeeperProps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_TestProps_TestPropId",
                table: "Paragraphs",
                column: "TestPropId",
                principalTable: "TestProps",
                principalColumn: "Id");
        }
    }
}
