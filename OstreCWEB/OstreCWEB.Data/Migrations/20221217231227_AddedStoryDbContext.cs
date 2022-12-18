using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class AddedStoryDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DialogProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogProps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FightProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightProps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopkeeperProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopkeeperProps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    TestDifficulty = table.Column<int>(type: "int", nullable: false),
                    ParagraphId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnemyInParagraphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfEnemy = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FightPropId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyInParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyInParagraphs_FightProps_FightPropId",
                        column: x => x.FightPropId,
                        principalTable: "FightProps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParagraphType = table.Column<int>(type: "int", nullable: false),
                    StageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FightPropId = table.Column<int>(type: "int", nullable: true),
                    DialogPropId = table.Column<int>(type: "int", nullable: true),
                    TestPropId = table.Column<int>(type: "int", nullable: true),
                    ShopkeeperPropId = table.Column<int>(type: "int", nullable: true),
                    StoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_DialogProps_DialogPropId",
                        column: x => x.DialogPropId,
                        principalTable: "DialogProps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paragraphs_FightProps_FightPropId",
                        column: x => x.FightPropId,
                        principalTable: "FightProps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paragraphs_ShopkeeperProps_ShopkeeperPropId",
                        column: x => x.ShopkeeperPropId,
                        principalTable: "ShopkeeperProps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paragraphs_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paragraphs_TestProps_TestPropId",
                        column: x => x.TestPropId,
                        principalTable: "TestProps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NextParagraphs",
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
                    table.PrimaryKey("PK_NextParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextParagraphs_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnemyInParagraphs_FightPropId",
                table: "EnemyInParagraphs",
                column: "FightPropId");

            migrationBuilder.CreateIndex(
                name: "IX_NextParagraphs_ParagraphId",
                table: "NextParagraphs",
                column: "ParagraphId");

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
                name: "IX_Paragraphs_StoryId",
                table: "Paragraphs",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_TestPropId",
                table: "Paragraphs",
                column: "TestPropId",
                unique: true,
                filter: "[TestPropId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnemyInParagraphs");

            migrationBuilder.DropTable(
                name: "NextParagraphs");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "DialogProps");

            migrationBuilder.DropTable(
                name: "FightProps");

            migrationBuilder.DropTable(
                name: "ShopkeeperProps");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "TestProps");
        }
    }
}
