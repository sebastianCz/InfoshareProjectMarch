using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    public partial class changedItemCharacterprimarykeyname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemCharacterId",
                table: "ItemsCharactersRelation",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemsCharactersRelation",
                newName: "ItemCharacterId");
        }
    }
}
