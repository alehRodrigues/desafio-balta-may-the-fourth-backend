using Microsoft.EntityFrameworkCore;
using StarisApi.Models.Characters;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.Movies;
using StarisApi.Models.MoviesPlanet;
using StarisApi.Models.MoviesStarship;
using StarisApi.Models.MoviesStarships;
using StarisApi.Models.MoviesVehicles;
using StarisApi.Models.Planets;
using StarisApi.Models.Starships;
using StarisApi.Models.StarShips;
using StarisApi.Models.Vehicles;

namespace StarisApi.DbContexts
{
    public class MySqlContext(DbContextOptions<MySqlContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Planet> Planets { get; set; } = null!;
        public DbSet<Starship> StarShips { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<CharacterMovie> CharacterMovies { get; set; } = null!;
        public DbSet<MoviePlanet> MoviesPlanets { get; set; } = null!;
        public DbSet<MovieStarship> MoviesStarships { get; set; } = null!;
        public DbSet<MovieVehicle> MoviesVehicles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterDbMap());
            modelBuilder.ApplyConfiguration(new MovieDbMap());
            modelBuilder.ApplyConfiguration(new PlanetDbMap());
            modelBuilder.ApplyConfiguration(new StarshipDbMap());
            modelBuilder.ApplyConfiguration(new VehicleDbMap());
            modelBuilder.ApplyConfiguration(new CharacterMovieDbMap());
            modelBuilder.ApplyConfiguration(new MoviePlanetDbMap());
            modelBuilder.ApplyConfiguration(new MovieStarshipDbMap());
            modelBuilder.ApplyConfiguration(new MovieVehicleDbMap());
        }
    }
}
