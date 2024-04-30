using StarisApi.Models.Movies;
using StarisApi.Models.Planets;

namespace StarisApi.Models.MoviesPlanet;

public class MoviePlanet
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int PlanetId { get; set; }

    public virtual Movie Movie { get; set; } = null!;
    public virtual Planet Planet { get; set; } = null!;

    public MoviePlanet MountRelation(int movieId, int planetId)
    {
        return new MoviePlanet { MovieId = movieId, PlanetId = planetId };
    }
}
