using System.Text.Json;
using StarisApi.Attributes;
using StarisApi.Dtos;
using StarisApi.Handlers;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.MoviesPlanet;
using StarisApi.Models.MoviesStarships;
using StarisApi.Models.MoviesVehicles;

namespace StarisApi.Models.Movies;

[NotProcessImage]
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

    public override T ConvertFromJson<T>(JsonElement info)
    {
        var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
        var id = DataBaseFeederHandler.GetIdFromUrl(splitedIdUrl);

        var movie = new Movie
        {
            Id = id,
            Title = info.GetProperty("title").GetString()!,
            Episode = info.GetProperty("episode_id").GetInt32().ToString(),
            OpeningCrawl = info.GetProperty("opening_crawl").GetString()!,
            Director = info.GetProperty("director").GetString()!,
            Producer = info.GetProperty("producer").GetString()!,
            ReleaseDate = info.GetProperty("release_date").GetString()!
        };
        movie.ImageUrl = DataBaseFeederHandler.ScrappyUrlImageForMovies(int.Parse(movie.Episode));

        return (T)(object)movie;
    }

    public override T ConvertToDto<T>()
    {
        var movie =
            new MovieDto
            {
                Id = Id,
                Title = Title,
                Episode = Episode,
                OpeningCrawl = OpeningCrawl,
                Director = Director,
                Production = Producer,
                ReleaseDate = ReleaseDate,
                ImageUrl = ImageUrl,
                Characters = Characters
                    .Select(x => new ListDto(x.CharacterId, x.Character.Name))
                    .ToList(),
                Planets = Planets.Select(x => new ListDto(x.PlanetId, x.Planet.Name)).ToList(),
                Vehicles = Vehicles.Select(x => new ListDto(x.VehicleId, x.Vehicle.Name)).ToList(),
                Starships = Starships
                    .Select(x => new ListDto(x.StarshipId, x.Starship.Name))
                    .ToList(),
            } as T;

        return movie!;
    }

    public override string GetSearchParameter() => "Title";
}
