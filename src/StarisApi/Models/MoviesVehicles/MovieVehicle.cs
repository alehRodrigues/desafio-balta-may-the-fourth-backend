using StarisApi.Models.Movies;
using StarisApi.Models.Vehicles;

namespace StarisApi.Models.MoviesVehicles;

public class MovieVehicle()
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int VehicleId { get; set; }

    public Movie Movie { get; set; } = null!;
    public Vehicle Vehicle { get; set; } = null!;
}