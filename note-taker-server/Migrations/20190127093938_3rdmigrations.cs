using Microsoft.EntityFrameworkCore.Migrations;

namespace notetakerserver.Migrations
{
    public partial class _3rdmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LanguageId",
                table: "Notes",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Languages_LanguageId",
                table: "Notes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Languages_LanguageId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_LanguageId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Notes");
        }
    }
}
