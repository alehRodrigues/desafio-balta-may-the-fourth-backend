﻿namespace StarisApi.Models.StarShips;

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

    //public ICollection<MovieStarship> Movies { get; set; } = [];

    public override T ConvertToDto<T>()
    {
        throw new NotImplementedException();
    }

    public override string GetSearchParameter()
    {
        throw new NotImplementedException();
    }
    
}