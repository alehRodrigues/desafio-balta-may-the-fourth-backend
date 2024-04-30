using System.Text.Json;
using StarisApi.Dtos;
using StarisApi.Handlers;
using StarisApi.Models.MoviesStarships;

namespace StarisApi.Models.StarShips;

public class Starship : Entity
{
    public string Model { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string StarshipClass { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string CostInCredits { get; set; } = null!;
    public string Lenght { get; set; } = null!;
    public string Crew { get; set; } = null!;
    public string Passengers { get; set; } = null!;
    public string MaxAtmospheringSpeed { get; set; } = null!;
    public string HyperDriveRating { get; set; } = null!;
    public string Megalights { get; set; } = null!;
    public string CargoCapacity { get; set; } = null!;
    public string Consumables { get; set; } = null!;

    public virtual ICollection<MovieStarship> Movies { get; set; } = [];

    public override T ConvertFromJson<T>(JsonElement info)
    {
        var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
        var id = DataBaseFeederHandler.GetIdFromUrl(splitedIdUrl);

        var starship = new Starship
        {
            Id = id,
            Model = info.GetProperty("model").GetString()!,
            Name = info.GetProperty("name").GetString()!,
            StarshipClass = info.GetProperty("starship_class").GetString()!,
            Manufacturer = info.GetProperty("manufacturer").GetString()!,
            CostInCredits = info.GetProperty("cost_in_credits").GetString()!,
            Lenght = info.GetProperty("length").GetString()!,
            Crew = info.GetProperty("crew").GetString()!,
            Passengers = info.GetProperty("passengers").GetString()!,
            MaxAtmospheringSpeed = info.GetProperty("max_atmosphering_speed").GetString()!,
            HyperDriveRating = info.GetProperty("hyperdrive_rating").GetString()!,
            Megalights = info.GetProperty("MGLT").GetString()!,
            CargoCapacity = info.GetProperty("cargo_capacity").GetString()!,
            Consumables = info.GetProperty("consumables").GetString()!
        };
        starship.ImageUrl =
            $"{starship._imgUrlBase}{DataBaseFeederHandler.StringImgUrlFixer(starship.Name)}";
        return (T)(object)starship;
    }

    public override T ConvertToDto<T>()
    {
        var starship =
            new StarshipDto
            {
                Id = Id,
                Model = Model,
                Name = Name,
                StarshipClass = StarshipClass,
                Manufacturer = Manufacturer,
                CostInCredits = CostInCredits,
                Lenght = Lenght,
                Crew = Crew,
                Passengers = Passengers,
                MaxAtmospheringSpeed = MaxAtmospheringSpeed,
                HyperDriveRating = HyperDriveRating,
                Megalights = Megalights,
                CargoCapacity = CargoCapacity,
                Consumables = Consumables,
                ImageUrl = ImageUrl,
                Movies = Movies.Select(x => new ListDto(x.MovieId, x.Movie.Title)).ToList(),
            } as T;

        return starship!;
    }

    public override string GetSearchParameter() => "Name";
}
