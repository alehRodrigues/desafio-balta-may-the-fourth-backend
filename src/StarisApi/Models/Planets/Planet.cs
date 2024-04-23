﻿using StarisApi.Dtos;
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
    public ICollection<Character> Characters { get; set; } = [];

    public ICollection<MoviePlanet> Movies { get; set; } = [];

    public override T ConvertToDto<T>()
    {
        var Planet = new PlanetDto
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
                Characters = Characters.Select(x => new ListDto(x.PlanetId, x.Planet.Name)).ToList(),
                Movies = Movies.Select(x => new ListDto(x.MovieId, x.Movie.Title)).ToList(),
            } as T;

            return Planet!;
    }

    public override string GetSearchParameter()
    {
        throw new NotImplementedException();
    }
    
}
