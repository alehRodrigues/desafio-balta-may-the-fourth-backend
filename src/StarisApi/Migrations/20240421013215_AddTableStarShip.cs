using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableStarShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StarShips",
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
                    table.PrimaryKey("PK_StarShips", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "StarShips");
        }
    }
}
