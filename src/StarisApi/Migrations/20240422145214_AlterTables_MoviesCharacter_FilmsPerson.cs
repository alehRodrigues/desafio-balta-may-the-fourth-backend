using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables_MoviesCharacter_FilmsPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Characters");

            migrationBuilder.DropTable(name: "CharactersMoviesRelationship");

            migrationBuilder.DropTable(name: "CharactersPlanetsRelationship");

            migrationBuilder.DropTable(name: "Movies");

            migrationBuilder.DropTable(name: "MoviesPlanetsRelationship");

            migrationBuilder.DropTable(name: "MovieStarshipsRelationship");

            migrationBuilder.DropTable(name: "MoviesVehiclesRelationship");

            migrationBuilder.CreateTable(
                name: "Films",
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
                    table.PrimaryKey("PK_Films", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmsPlanets",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsPlanets", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmsStarships",
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
                    table.PrimaryKey("PK_FilmsStarships", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmVehicles",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmVehicles", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    BirthYear = table.Column<string>(type: "varchar(30)", nullable: false),
                    EyeColor = table.Column<string>(type: "varchar(30)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(30)", nullable: false),
                    HairColor = table.Column<string>(type: "varchar(30)", nullable: false),
                    Height = table.Column<string>(type: "varchar(30)", nullable: false),
                    Mass = table.Column<string>(type: "varchar(30)", nullable: false),
                    SkinColor = table.Column<string>(type: "varchar(30)", nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "PeopleMovies",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleMovies", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "PeoplePlanets",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeoplePlanets", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_People_PlanetId",
                table: "People",
                column: "PlanetId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Films");

            migrationBuilder.DropTable(name: "FilmsPlanets");

            migrationBuilder.DropTable(name: "FilmsStarships");

            migrationBuilder.DropTable(name: "FilmVehicles");

            migrationBuilder.DropTable(name: "People");

            migrationBuilder.DropTable(name: "PeopleMovies");

            migrationBuilder.DropTable(name: "PeoplePlanets");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthYear = table.Column<string>(type: "varchar(30)", nullable: false),
                    EyeColor = table.Column<string>(type: "varchar(30)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(30)", nullable: false),
                    HairColor = table.Column<string>(type: "varchar(30)", nullable: false),
                    Height = table.Column<string>(type: "varchar(30)", nullable: false),
                    Mass = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    SkinColor = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CharactersMoviesRelationship",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMoviesRelationship", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "CharactersPlanetsRelationship",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersPlanetsRelationship", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Director = table.Column<string>(type: "varchar(50)", nullable: false),
                    Episode = table.Column<int>(type: "int", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "varchar(50)", nullable: false),
                    Producer = table.Column<string>(type: "varchar(50)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "varchar(50)", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "MoviesPlanetsRelationship",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesPlanetsRelationship", x => x.Id);
                }
            );

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

            migrationBuilder.CreateTable(
                name: "MoviesVehiclesRelationship",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesVehiclesRelationship", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
                column: "PlanetId"
            );
        }
    }
}
