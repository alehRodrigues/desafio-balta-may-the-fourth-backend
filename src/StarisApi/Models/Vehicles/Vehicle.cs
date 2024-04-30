using System.Text.Json;
using StarisApi.Dtos;
using StarisApi.Handlers;
using StarisApi.Models.MoviesVehicles;

namespace StarisApi.Models.Vehicles;

public class Vehicle : Entity
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string VehicleClass { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Lenght { get; set; } = null!;
    public string CostInCredits { get; set; } = null!;
    public string Crew { get; set; } = null!;
    public string Passengers { get; set; } = null!;
    public string MaxAtmospheringSpeed { get; set; } = null!;
    public string CargoCapacity { get; set; } = null!;
    public string Consumables { get; set; } = null!;

    public virtual ICollection<MovieVehicle> Movies { get; set; } = [];

    public override T ConvertFromJson<T>(JsonElement info)
    {
        var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
        var id = DataBaseFeederHandler.GetIdFromUrl(splitedIdUrl);
        var name = DataBaseFeederHandler.StringNamesFixer(info.GetProperty("name").GetString()!);
        var vehicle = new Vehicle
        {
            Id = id,
            Model = info.GetProperty("model").GetString()!,
            Name = name,
            VehicleClass = info.GetProperty("vehicle_class").GetString()!,
            Manufacturer = info.GetProperty("manufacturer").GetString()!,
            CostInCredits = info.GetProperty("cost_in_credits").GetString()!,
            Lenght = info.GetProperty("length").GetString()!,
            Crew = info.GetProperty("crew").GetString()!,
            Passengers = info.GetProperty("passengers").GetString()!,
            MaxAtmospheringSpeed = info.GetProperty("max_atmosphering_speed").GetString()!,
            CargoCapacity = info.GetProperty("cargo_capacity").GetString()!,
            Consumables = info.GetProperty("consumables").GetString()!
        };
        vehicle.ImageUrl =
            $"{vehicle._imgUrlBase}{DataBaseFeederHandler.StringImgUrlFixer(vehicle.Name)}";
        return (T)(object)vehicle;
    }

    public override T ConvertToDto<T>()
    {
        var vehicle =
            new VehicleDto
            {
                Id = Id,
                Name = Name,
                Model = Model,
                VehicleClass = VehicleClass,
                Manufacturer = Manufacturer,
                Lenght = Lenght,
                CostInCredits = CostInCredits,
                Crew = Crew,
                Passengers = Passengers,
                MaxAtmospheringSpeed = MaxAtmospheringSpeed,
                CargoCapacity = CargoCapacity,
                Consumables = Consumables,
                ImageUrl = ImageUrl,
                Movies = Movies.Select(x => new ListDto(x.MovieId, x.Movie.Title)).ToList()
            } as T;

        return vehicle!;
    }

    public override string GetSearchParameter() => "Name";
}
