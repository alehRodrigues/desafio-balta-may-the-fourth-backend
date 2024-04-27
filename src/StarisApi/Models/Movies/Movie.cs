using StarisApi.Dtos;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.MoviesPlanet;
using StarisApi.Models.MoviesStarships;
using StarisApi.Models.MoviesVehicles;

namespace StarisApi.Models.Movies;

public class Movie : Entity
{
    public string Title { get; set; } = null!;
    public string Episode { get; set; } = null!;
    public string OpeningCrawl { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Producer { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;
    public virtual ICollection<CharacterMovie> Characters { get; set; } = [];
    public virtual ICollection<MoviePlanet> Planets { get; set; } = [];
    public virtual ICollection<MovieVehicle> Vehicles { get; set; } = [];
    public virtual ICollection<MovieStarship> Starships { get; set; } = [];

        public override T ConvertToDto<T>()
        {
            var movie = new MovieDto
            {
                Id = Id,
                Title = Title,
                Episode = Episode,
                OpeningCrawl = OpeningCrawl,
                Director = Director,
                Production = Producer,
                ReleaseDate = ReleaseDate,
                ImageUrl = ImageUrl,
                Characters = Characters.Select(x => new ListDto(x.CharacterId, x.Character.Name)).ToList(),
                Planets = Planets.Select(x => new ListDto(x.PlanetId, x.Planet.Name)).ToList(),
                Vehicles = Vehicles.Select(x => new ListDto(x.VehicleId, x.Vehicle.Name)).ToList(),
                Starships = Starships.Select(x => new ListDto(x.StarshipId, x.Starship.Name)).ToList(),
            } as T;

            return movie!;
        }

    public override string GetSearchParameter() => "Title";
    
}
