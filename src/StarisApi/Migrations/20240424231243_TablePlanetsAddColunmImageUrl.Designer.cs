﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarisApi.DbContexts;

#nullable disable

namespace StarisApi.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20240424231243_TablePlanetsAddColunmImageUrl")]
    partial class TablePlanetsAddColunmImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("StarisApi.Models.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("");

                    b.Property<string>("Mass")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.CharactersMovies.CharacterMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharactersMovies", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.Movies.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Episode")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasAnnotation("CheckConstraint", "CK_Episode_MinValue: Episode >= 1");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Movies", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.MoviesPlanet.MoviePlanet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("PlanetId");

                    b.ToTable("MoviesPlanets", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.MoviesStarships.MovieStarship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("StarshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("StarshipId");

                    b.ToTable("MoviesStarships", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.MoviesVehicles.MovieVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("VehicleId");

                    b.ToTable("MoviesVehicles", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.Planets.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Diameter")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Gravity")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("OrbitalPeriod")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("RotationSpeed")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SurfaceWater")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Planets", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.StarShips.Starship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("HyperDriveRating")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Lenght")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("MaxAtmospheringSpeed")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Megalights")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StarshipClass")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Starships", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Lenght")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("MaxAtmospheringSpeed")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("VehicleClass")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.Characters.Character", b =>
                {
                    b.HasOne("StarisApi.Models.Planets.Planet", "Planet")
                        .WithMany("Characters")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("StarisApi.Models.CharactersMovies.CharacterMovie", b =>
                {
                    b.HasOne("StarisApi.Models.Characters.Character", "Character")
                        .WithMany("Movies")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarisApi.Models.Movies.Movie", "Movie")
                        .WithMany("Characters")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("StarisApi.Models.MoviesPlanet.MoviePlanet", b =>
                {
                    b.HasOne("StarisApi.Models.Movies.Movie", "Movie")
                        .WithMany("Planets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarisApi.Models.Planets.Planet", "Planet")
                        .WithMany("Movies")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("StarisApi.Models.MoviesStarships.MovieStarship", b =>
                {
                    b.HasOne("StarisApi.Models.Movies.Movie", "Movie")
                        .WithMany("Starships")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarisApi.Models.StarShips.Starship", "Starship")
                        .WithMany("Movies")
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Starship");
                });

            modelBuilder.Entity("StarisApi.Models.MoviesVehicles.MovieVehicle", b =>
                {
                    b.HasOne("StarisApi.Models.Movies.Movie", "Movie")
                        .WithMany("Vehicles")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarisApi.Models.Vehicles.Vehicle", "Vehicle")
                        .WithMany("Movies")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("StarisApi.Models.Characters.Character", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("StarisApi.Models.Movies.Movie", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Planets");

                    b.Navigation("Starships");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("StarisApi.Models.Planets.Planet", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("StarisApi.Models.StarShips.Starship", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("StarisApi.Models.Vehicles.Vehicle", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
