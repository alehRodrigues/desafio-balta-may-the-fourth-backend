using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Model = table.Column<string>(type: "varchar(30)", nullable: false),
                    VehicleClass = table.Column<string>(type: "varchar(30)", nullable: false),
                    Manufacturer = table.Column<string>(type: "varchar(30)", nullable: false),
                    Lenght = table.Column<string>(type: "varchar(30)", nullable: false),
                    CostInCredits = table.Column<string>(type: "varchar(30)", nullable: false),
                    Crew = table.Column<string>(type: "varchar(30)", nullable: false),
                    Passengers = table.Column<string>(type: "varchar(30)", nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(
                        type: "varchar(30)",
                        nullable: false
                    ),
                    CargoCapacity = table.Column<string>(type: "varchar(30)", nullable: false),
                    Consumables = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Vehicles");
        }
    }
}
