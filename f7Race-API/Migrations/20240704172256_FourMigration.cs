using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace f7Race_API.Migrations
{
    /// <inheritdoc />
    public partial class FourMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Seasons_SeasonId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Seasons_SeasonId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_SeasonId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Brands_SeasonId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Brands");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonRaces_SeasonId",
                table: "SeasonRaces",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonBrands_SeasonId",
                table: "SeasonBrands",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonBrands_Seasons_SeasonId",
                table: "SeasonBrands",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonRaces_Seasons_SeasonId",
                table: "SeasonRaces",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonBrands_Seasons_SeasonId",
                table: "SeasonBrands");

            migrationBuilder.DropForeignKey(
                name: "FK_SeasonRaces_Seasons_SeasonId",
                table: "SeasonRaces");

            migrationBuilder.DropIndex(
                name: "IX_SeasonRaces_SeasonId",
                table: "SeasonRaces");

            migrationBuilder.DropIndex(
                name: "IX_SeasonBrands_SeasonId",
                table: "SeasonBrands");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Races",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Brands",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_SeasonId",
                table: "Races",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_SeasonId",
                table: "Brands",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Seasons_SeasonId",
                table: "Brands",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Seasons_SeasonId",
                table: "Races",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId");
        }
    }
}
