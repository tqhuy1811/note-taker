using Microsoft.EntityFrameworkCore.Migrations;

namespace notetakerserver.Migrations
{
    public partial class UpgradeLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Languages_Title",
                table: "Languages",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Languages_Title",
                table: "Languages");
        }
    }
}
