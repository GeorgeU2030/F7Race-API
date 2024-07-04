using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace f7Race_API.Migrations
{
    /// <inheritdoc />
    public partial class FiveMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trophy_Brands_BrandId",
                table: "Trophy");

            migrationBuilder.DropForeignKey(
                name: "FK_Trophy_Races_RaceId",
                table: "Trophy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trophy",
                table: "Trophy");

            migrationBuilder.RenameTable(
                name: "Trophy",
                newName: "Trophies");

            migrationBuilder.RenameIndex(
                name: "IX_Trophy_RaceId",
                table: "Trophies",
                newName: "IX_Trophies_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Trophy_BrandId",
                table: "Trophies",
                newName: "IX_Trophies_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trophies",
                table: "Trophies",
                column: "TrophyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_Brands_BrandId",
                table: "Trophies",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_Races_RaceId",
                table: "Trophies",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_Brands_BrandId",
                table: "Trophies");

            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_Races_RaceId",
                table: "Trophies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trophies",
                table: "Trophies");

            migrationBuilder.RenameTable(
                name: "Trophies",
                newName: "Trophy");

            migrationBuilder.RenameIndex(
                name: "IX_Trophies_RaceId",
                table: "Trophy",
                newName: "IX_Trophy_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Trophies_BrandId",
                table: "Trophy",
                newName: "IX_Trophy_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trophy",
                table: "Trophy",
                column: "TrophyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trophy_Brands_BrandId",
                table: "Trophy",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trophy_Races_RaceId",
                table: "Trophy",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
