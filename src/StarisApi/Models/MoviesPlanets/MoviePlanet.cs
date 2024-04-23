using StarisApi.Models.Movies;
using StarisApi.Models.Planets;

namespace StarisApi.Models.MoviesPlanet;

public class MoviePlanet
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int PlanetId { get; set; }

    public Movie Movie {get; set; } = null!;
    public Planet Planet { get; set; } = null!;
}
