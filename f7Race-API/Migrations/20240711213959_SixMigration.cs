using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace f7Race_API.Migrations
{
    /// <inheritdoc />
    public partial class SixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrophyCountDto",
                columns: table => new
                {
                    RaceName = table.Column<string>(type: "text", nullable: false),
                    FlagRace = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrophyCountDto");
        }
    }
}
