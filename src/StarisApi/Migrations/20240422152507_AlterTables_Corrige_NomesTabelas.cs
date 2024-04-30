using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables_Corrige_NomesTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    StarshipClass = table.Column<string>(type: "varchar(30)", nullable: false),
                    Manufacturer = table.Column<string>(type: "varchar(30)", nullable: false),
                    CostInCredits = table.Column<string>(type: "varchar(30)", nullable: false),
                    Lenght = table.Column<string>(type: "varchar(30)", nullable: false),
                    Crew = table.Column<string>(type: "varchar(30)", nullable: false),
                    Passengers = table.Column<string>(type: "varchar(30)", nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(
                        type: "varchar(30)",
                        nullable: false
                    ),
                    HyperDriveRating = table.Column<string>(type: "varchar(30)", nullable: false),
                    Megalights = table.Column<string>(type: "varchar(30)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "varchar(30)", nullable: false),
                    Consumables = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                }
            );

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "PeoplePlanets",
                newName: "PersonId"
            );

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "PeopleMovies",
                newName: "PersonId"
            );

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "PeopleMovies",
                newName: "FilmId"
            );

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "FilmVehicles",
                newName: "FilmId"
            );

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "FilmsStarships",
                newName: "FilmId"
            );

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "FilmsPlanets",
                newName: "FilmId"
            );

            migrationBuilder.AddPrimaryKey(name: "PK_Starships", table: "Starships", column: "Id");

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
                name: "IX_FilmsPlanets_FilmId",
                table: "FilmsPlanets",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmsPlanets_PlanetId",
                table: "FilmsPlanets",
                column: "PlanetId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsPlanets_Films_FilmId",
                table: "FilmsPlanets",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsPlanets_Planets_PlanetId",
                table: "FilmsPlanets",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsStarships_Films_FilmId",
                table: "FilmsStarships",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_FilmsStarships_Starships_StarshipId",
                table: "FilmsStarships",
                column: "StarshipId",
                principalTable: "Starships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_FilmVehicles_Films_FilmId",
                table: "FilmVehicles",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_FilmVehicles_Vehicles_VehicleId",
                table: "FilmVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleMovies_Films_FilmId",
                table: "PeopleMovies",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleMovies_People_PersonId",
                table: "PeopleMovies",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PeoplePlanets_People_PersonId",
                table: "PeoplePlanets",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PeoplePlanets_Planets_PlanetId",
                table: "PeoplePlanets",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "StarShips");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmsPlanets_Films_FilmId",
                table: "FilmsPlanets"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_FilmsPlanets_Planets_PlanetId",
                table: "FilmsPlanets"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_FilmsStarships_Films_FilmId",
                table: "FilmsStarships"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_FilmsStarships_Starships_StarshipId",
                table: "FilmsStarships"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_FilmVehicles_Films_FilmId",
                table: "FilmVehicles"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_FilmVehicles_Vehicles_VehicleId",
                table: "FilmVehicles"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleMovies_Films_FilmId",
                table: "PeopleMovies"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleMovies_People_PersonId",
                table: "PeopleMovies"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PeoplePlanets_People_PersonId",
                table: "PeoplePlanets"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PeoplePlanets_Planets_PlanetId",
                table: "PeoplePlanets"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Starships", table: "Starships");

            migrationBuilder.DropIndex(name: "IX_PeoplePlanets_PersonId", table: "PeoplePlanets");

            migrationBuilder.DropIndex(name: "IX_PeoplePlanets_PlanetId", table: "PeoplePlanets");

            migrationBuilder.DropIndex(name: "IX_PeopleMovies_FilmId", table: "PeopleMovies");

            migrationBuilder.DropIndex(name: "IX_PeopleMovies_PersonId", table: "PeopleMovies");

            migrationBuilder.DropIndex(name: "IX_FilmVehicles_FilmId", table: "FilmVehicles");

            migrationBuilder.DropIndex(name: "IX_FilmVehicles_VehicleId", table: "FilmVehicles");

            migrationBuilder.DropIndex(name: "IX_FilmsStarships_FilmId", table: "FilmsStarships");

            migrationBuilder.DropIndex(
                name: "IX_FilmsStarships_StarshipId",
                table: "FilmsStarships"
            );

            migrationBuilder.DropIndex(name: "IX_FilmsPlanets_FilmId", table: "FilmsPlanets");

            migrationBuilder.DropIndex(name: "IX_FilmsPlanets_PlanetId", table: "FilmsPlanets");

            migrationBuilder.RenameTable(name: "Starships", newName: "StarShips");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PeoplePlanets",
                newName: "CharacterId"
            );

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PeopleMovies",
                newName: "MovieId"
            );

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "PeopleMovies",
                newName: "CharacterId"
            );

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "FilmVehicles",
                newName: "MovieId"
            );

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "FilmsStarships",
                newName: "MovieId"
            );

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "FilmsPlanets",
                newName: "MovieId"
            );

            migrationBuilder.AddPrimaryKey(name: "PK_StarShips", table: "StarShips", column: "Id");
        }
    }
}
