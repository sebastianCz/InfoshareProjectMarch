using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class RenameTableChoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextParagraphs");

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextParagraphId = table.Column<int>(type: "int", nullable: false),
                    ParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ParagraphId",
                table: "Choices",
                column: "ParagraphId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.CreateTable(
                name: "NextParagraphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParagraphId = table.Column<int>(type: "int", nullable: false),
                    ChoiceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextParagraphs_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NextParagraphs_ParagraphId",
                table: "NextParagraphs",
                column: "ParagraphId");
        }
    }
}
