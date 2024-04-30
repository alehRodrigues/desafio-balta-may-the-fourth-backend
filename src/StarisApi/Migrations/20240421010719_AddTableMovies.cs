using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Episode = table.Column<int>(type: "int", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "varchar(50)", nullable: false),
                    Director = table.Column<string>(type: "varchar(50)", nullable: false),
                    Producer = table.Column<string>(type: "varchar(50)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Movies");
        }
    }
}
