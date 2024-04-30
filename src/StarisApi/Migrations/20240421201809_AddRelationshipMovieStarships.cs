using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipMovieStarships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieStarshipsRelationship",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    StarshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStarshipsRelationship", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MovieStarshipsRelationship");
        }
    }
}
