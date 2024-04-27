using StarisApi.Dtos;
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

    public override T ConvertToDto<T>()
    {

        var vehicle = new VehiclesDto
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
