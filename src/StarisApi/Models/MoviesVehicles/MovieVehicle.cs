using StarisApi.Models.Movies;
using StarisApi.Models.Vehicles;

namespace StarisApi.Models.MoviesVehicles;

public class MovieVehicle()
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int VehicleId { get; set; }

    public virtual Movie Movie { get; set; } = null!;
    public virtual Vehicle Vehicle { get; set; } = null!;

    public MovieVehicle MountRelation(int movieId, int planetId)
    {
        return new MovieVehicle { MovieId = movieId, VehicleId = planetId };
    }
}
