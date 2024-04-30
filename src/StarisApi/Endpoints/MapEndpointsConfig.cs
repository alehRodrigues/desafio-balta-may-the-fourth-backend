using StarisApi.Dtos;
using StarisApi.Models.Characters;
using StarisApi.Models.Movies;
using StarisApi.Models.Planets;
using StarisApi.Models.StarShips;
using StarisApi.Models.Vehicles;

namespace StarisApi.Endpoints
{
    public static class MapEndpointsConfig
    {
        //Adicionar os endpoints aqui
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGenericEndpoint<Character, CharacterDto>();
            app.MapGenericEndpoint<Movie, MovieDto>();
            app.MapGenericEndpoint<Planet, PlanetDto>();
            app.MapGenericEndpoint<Starship, StarshipDto>();
            app.MapGenericEndpoint<Vehicle, VehicleDto>();
            return app;
        }

        public static IEndpointRouteBuilder MapFeeder(this IEndpointRouteBuilder app)
        {
            app.MapDatabaseFeederEndpoits<Character>();
            app.MapDatabaseFeederEndpoits<Planet>();
            app.MapDatabaseFeederEndpoits<Vehicle>();
            app.MapDatabaseFeederEndpoits<Starship>();
            app.MapDatabaseFeederEndpoits<Movie>();
            return app;
        }
    }
}
