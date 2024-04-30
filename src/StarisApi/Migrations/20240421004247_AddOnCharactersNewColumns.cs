using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarisApi.Migrations
{
    /// <inheritdoc />
    public partial class AddOnCharactersNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthYear",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Mass",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "SkinColor",
                table: "Characters",
                type: "varchar(30)",
                nullable: false,
                defaultValue: ""
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "BirthYear", table: "Characters");

            migrationBuilder.DropColumn(name: "EyeColor", table: "Characters");

            migrationBuilder.DropColumn(name: "Gender", table: "Characters");

            migrationBuilder.DropColumn(name: "HairColor", table: "Characters");

            migrationBuilder.DropColumn(name: "Height", table: "Characters");

            migrationBuilder.DropColumn(name: "Mass", table: "Characters");

            migrationBuilder.DropColumn(name: "SkinColor", table: "Characters");
        }
    }
}
