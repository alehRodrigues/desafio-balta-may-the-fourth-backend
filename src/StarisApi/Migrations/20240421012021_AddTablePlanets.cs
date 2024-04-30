using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePlanets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Diameter = table.Column<string>(type: "varchar(30)", nullable: false),
                    RotationSpeed = table.Column<string>(type: "varchar(30)", nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "varchar(30)", nullable: false),
                    Gravity = table.Column<string>(type: "varchar(30)", nullable: false),
                    Population = table.Column<string>(type: "varchar(30)", nullable: false),
                    Climate = table.Column<string>(type: "varchar(30)", nullable: false),
                    Terrain = table.Column<string>(type: "varchar(30)", nullable: false),
                    SurfaceWater = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Planets");
        }
    }
}
