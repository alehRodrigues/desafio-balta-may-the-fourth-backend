using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables_Rename_Movie_People_Film_Character : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "FilmsPlanets");

            migrationBuilder.DropTable(name: "FilmsStarships");

            migrationBuilder.DropTable(name: "FilmVehicles");

            migrationBuilder.DropTable(name: "PeopleMovies");

            migrationBuilder.DropTable(name: "PeoplePlanets");

            migrationBuilder.DropTable(name: "Films");

            migrationBuilder.DropTable(name: "People");

            migrationBuilder.CreateTable(
                name: "Characters",
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

            migrationBuilder.CreateTable(
                name: "CharacetsPlanets",
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
                    table.PrimaryKey("PK_CharacetsPlanets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacetsPlanets_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CharacetsPlanets_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CharactersMovies",
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
                    table.PrimaryKey("PK_CharactersMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharactersMovies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CharactersMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "MoviesPlanets",
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
                    table.PrimaryKey("PK_MoviesPlanets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesPlanets_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_MoviesPlanets_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "MoviesStarships",
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
                    table.PrimaryKey("PK_MoviesStarships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesStarships_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_MoviesStarships_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "MoviesVehicles",
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
                    table.PrimaryKey("PK_MoviesVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesVehicles_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_MoviesVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_CharacetsPlanets_CharacterId",
                table: "CharacetsPlanets",
                column: "CharacterId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CharacetsPlanets_PlanetId",
                table: "CharacetsPlanets",
                column: "PlanetId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
                column: "PlanetId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovies_CharacterId",
                table: "CharactersMovies",
                column: "CharacterId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovies_MovieId",
                table: "CharactersMovies",
                column: "MovieId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_MoviesPlanets_MovieId",
                table: "MoviesPlanets",
                column: "MovieId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_MoviesPlanets_PlanetId",
                table: "MoviesPlanets",
                column: "PlanetId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_MoviesStarships_MovieId",
                table: "MoviesStarships",
                column: "MovieId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_MoviesStarships_StarshipId",
                table: "MoviesStarships",
                column: "StarshipId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_MoviesVehicles_MovieId",
                table: "MoviesVehicles",
                column: "MovieId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_MoviesVehicles_VehicleId",
                table: "MoviesVehicles",
                column: "VehicleId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CharacetsPlanets");

            migrationBuilder.DropTable(name: "CharactersMovies");

            migrationBuilder.DropTable(name: "MoviesPlanets");

            migrationBuilder.DropTable(name: "MoviesStarships");

            migrationBuilder.DropTable(name: "MoviesVehicles");

            migrationBuilder.DropTable(name: "Characters");

            migrationBuilder.DropTable(name: "Movies");

            migrationBuilder.CreateTable(
                name: "Films",
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
                    table.PrimaryKey("PK_Films", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "People",
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
                name: "FilmsPlanets",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsPlanets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsPlanets_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FilmsPlanets_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmsStarships",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    StarshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsStarships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmsStarships_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FilmsStarships_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmVehicles",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmVehicles_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FilmVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
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
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleMovies_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_PeopleMovies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "PeoplePlanets",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeoplePlanets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeoplePlanets_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_PeoplePlanets_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmsPlanets_FilmId",
                table: "FilmsPlanets",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmsPlanets_PlanetId",
                table: "FilmsPlanets",
                column: "PlanetId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmsStarships_FilmId",
                table: "FilmsStarships",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmsStarships_StarshipId",
                table: "FilmsStarships",
                column: "StarshipId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicles_FilmId",
                table: "FilmVehicles",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicles_VehicleId",
                table: "FilmVehicles",
                column: "VehicleId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_People_PlanetId",
                table: "People",
                column: "PlanetId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PeopleMovies_FilmId",
                table: "PeopleMovies",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PeopleMovies_PersonId",
                table: "PeopleMovies",
                column: "PersonId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PeoplePlanets_PersonId",
                table: "PeoplePlanets",
                column: "PersonId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PeoplePlanets_PlanetId",
                table: "PeoplePlanets",
                column: "PlanetId"
            );
        }
    }
}
