﻿using StarisApi.Dtos;
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
    public string ImageUrl { get; set; } = string.Empty!;

    public virtual ICollection<MovieStarship> Movies { get; set; } = [];

    public override T ConvertToDto<T>()
    {
        var starship = new StarshipDto
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
