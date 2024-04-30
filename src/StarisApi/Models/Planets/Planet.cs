using System.Text.Json;
using StarisApi.Dtos;
using StarisApi.Handlers;
using StarisApi.Models.Characters;
using StarisApi.Models.MoviesPlanet;

namespace StarisApi.Models.Planets;

public class Planet : Entity
{
    public string Name { get; set; } = null!;
    public string Diameter { get; set; } = null!;
    public string RotationSpeed { get; set; } = null!;
    public string OrbitalPeriod { get; set; } = null!;
    public string Gravity { get; set; } = null!;
    public string Population { get; set; } = null!;
    public string Climate { get; set; } = null!;
    public string Terrain { get; set; } = null!;
    public string SurfaceWater { get; set; } = null!;
    public virtual ICollection<Character> Characters { get; set; } = [];

    public virtual ICollection<MoviePlanet> Movies { get; set; } = [];

    public override T ConvertFromJson<T>(JsonElement info)
    {
        var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
        var id = DataBaseFeederHandler.GetIdFromUrl(splitedIdUrl);

        var planet = new Planet
        {
            Id = id,
            Name = info.GetProperty("name").GetString()!,
            Diameter = info.GetProperty("diameter").GetString()!,
            RotationSpeed = info.GetProperty("rotation_period").GetString()!,
            OrbitalPeriod = info.GetProperty("orbital_period").GetString()!,
            Gravity = info.GetProperty("gravity").GetString()!,
            Population = info.GetProperty("population").GetString()!,
            Climate = info.GetProperty("climate").GetString()!,
            Terrain = info.GetProperty("terrain").GetString()!,
            SurfaceWater = info.GetProperty("surface_water").GetString()!
        };
        planet.ImageUrl = $"{planet._imgUrlBase}{planet.Name.Replace(" ", "_")}";

        return (T)(object)planet;
    }

    public override T ConvertToDto<T>()
    {
        var Planet =
            new PlanetDto
            {
                Id = Id,
                Name = Name,
                Diameter = Diameter,
                RotationSpeed = RotationSpeed,
                OrbitalPeriod = OrbitalPeriod,
                Gravity = Gravity,
                Population = Population,
                Climate = Climate,
                Terrain = Terrain,
                SurfaceWater = SurfaceWater,
                ImageUrl = ImageUrl,
                Characters = Characters.Select(x => new ListDto(x.Id, x.Name)).ToList(),
                Movies = Movies.Select(x => new ListDto(x.MovieId, x.Movie.Title)).ToList(),
            } as T;

        return Planet!;
    }

    public override string GetSearchParameter() => "Name";
}
