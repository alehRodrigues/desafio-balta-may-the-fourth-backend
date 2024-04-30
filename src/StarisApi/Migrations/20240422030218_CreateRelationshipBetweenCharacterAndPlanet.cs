using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipBetweenCharacterAndPlanet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
                column: "PlanetId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Planets_PlanetId",
                table: "Characters",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Planets_PlanetId",
                table: "Characters"
            );

            migrationBuilder.DropIndex(name: "IX_Characters_PlanetId", table: "Characters");

            migrationBuilder.DropColumn(name: "PlanetId", table: "Characters");
        }
    }
}
