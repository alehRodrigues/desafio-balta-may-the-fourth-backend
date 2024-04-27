using StarisApi.DbContexts;
using StarisApi.Dtos;
using StarisApi.Extensions;
using StarisApi.Models;
using StarisApi.Models.Characters;
using StarisApi.Repository;

namespace StarisApi.Endpoints.DataBaseFeeders;
//teste
public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits(this IEndpointRouteBuilder app)
    {
        //      app.MapGet("/seed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //      {
        //          var infosMovies = await feeder.GetInfoFromMoviesEndpoint();
        //          var infosCharacters = await feeder.GetInfoFromPeopleEndpoint();
        //          var infoPlanets = await feeder.GetInfoFromPlanetsEndpoint();
        //          var infoStarShips = await feeder.GetInfoFromStarshiptEndpoint();
        //          var infoVehicles = await feeder.GetInfoFromVehicleEndpoint();

        //          var filmsBase = feeder.GetMoviesBase(infosMovies);
        //          var charactersBase = feeder.GetCharactersBase(infosCharacters);
        //          var planetsBase = feeder.GetPlanetsBase(infoPlanets);
        //          var starshipsBase = feeder.GetStarshipsBase(infoStarShips);
        //          var vehiclesBase = feeder.GetVehiclesBase(infoVehicles);

        //          //context.Movies.AddRange(filmsBase);
        //          //context.Characters.AddRange(charactersBase);
        //          //context.Planets.AddRange(planetsBase);
        //          //context.StarShips.AddRange(starshipsBase);
        //          //context.Vehicles.AddRange(vehiclesBase);

        //          var relationCharacterMovie = feeder.GetCharacterMovieRelation(filmsBase, charactersBase);
        //          var relationMoviePlanet = feeder.GetMoviePlanetRelation(filmsBase, planetsBase);
        //          var relationMovieVehicle = feeder.GetMovieVehicleRelation(filmsBase, vehiclesBase);
        //          var relationMovieStarship = feeder.GetMovieStarshipRelation(filmsBase, starshipsBase);

        //          //context.CharacterMovies.AddRange(relationCharacterMovie);
        //          //context.MoviesPlanets.AddRange(relationMoviePlanet);
        //          //context.MoviesStarships.AddRange(relationMovieStarship);
        //          //context.MoviesVehicles.AddRange(relationMovieVehicle);

        //          //var movies = feeder.GetMovies(filmsBase, relationMovieVehicle, relationMoviePlanet, relationMovieStarship, relationCharacterMovie);
        //          //var characters = feeder.GetCharacters(charactersBase, relationCharacterMovie);

        //          //await context.SaveChangesAsync();

        //          return infosMovies.Count != 0 ? TypedResults.Ok("TEST") : Results.NoContent();
        //      }).WithTags("Seed")
        //        .WithOpenApi();

        //      app.MapPost("/CharacterImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //      {
        //          try
        //          {
        //              var characters = context.Characters.ToList();
        //              var characterIdNames = characters.ToDictionary(character => character.Id, character => character.Name);
        //              var imagesUrlRelations = await feeder.ScrappyUrlImage(characterIdNames);

        //              characters.ForEach(character =>
        //              {
        //                  if (imagesUrlRelations.TryGetValue(character.Id, out string? link))
        //                  {
        //                      character.ImageUrl = link ?? string.Empty;
        //                  }
        //              });

        //              context.Characters.UpdateRange(characters);
        //              await context.SaveChangesAsync();
        //          }
        //          catch (Exception ex)
        //          {
        //              Console.WriteLine(ex.ToString());
        //              return Results.BadRequest();
        //          }

        //          return TypedResults.Ok("Characters Image URL feed with success.");

        //      }).WithTags("Seed")
        //        .WithOpenApi();

        //      app.MapPost("/PlanetImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //      {
        //          try
        //          {
        //              var planets = context.Planets.ToList();
        //              var planetIdNames = planets.ToDictionary(planet => planet.Id, planet => planet.Name);
        //              var imagesUrlRelations = await feeder.ScrappyUrlImage(planetIdNames);

        //              planets.ForEach(planet =>
        //              {
        //                  if (imagesUrlRelations.TryGetValue(planet.Id, out string? link))
        //                  {
        //                      planet.ImageUrl = link ?? string.Empty;
        //                  }
        //              });

        //              context.Planets.UpdateRange(planets);
        //              await context.SaveChangesAsync();
        //          }
        //          catch (Exception ex)
        //          {
        //              Console.WriteLine(ex.ToString());
        //              return Results.BadRequest();
        //          }

        //          return TypedResults.Ok("Planets Image URL feed with success.");

        //      }).WithTags("Seed")
        //        .WithOpenApi();

        //      app.MapPost("/StarshipImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //      {
        //          try
        //          {
        //              var starShips = context.StarShips.ToList();
        //              var starShipIdNames = starShips.ToDictionary(starShip => starShip.Id, starShip => starShip.Name);
        //              var imagesUrlRelations = await feeder.ScrappyUrlImage(starShipIdNames);

        //              starShips.ForEach(starShip =>
        //              {
        //                  if (imagesUrlRelations.TryGetValue(starShip.Id, out string? link))
        //                  {
        //                      starShip.ImageUrl = link ?? string.Empty;
        //                  }
        //              });

        //              context.StarShips.UpdateRange(starShips);
        //              await context.SaveChangesAsync();
        //          }
        //          catch (Exception ex)
        //          {
        //              Console.WriteLine(ex.ToString());
        //              return Results.BadRequest();
        //          }

        //          return TypedResults.Ok("StarShips Image URL feed with success.");

        //      }).WithTags("Seed")
        //        .WithOpenApi();

        //      app.MapPost("/VehicleImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //      {
        //          try
        //          {
        //              var vehicles = context.Vehicles.ToList();
        //              var vehicleNames = vehicles.ToDictionary(vehicle => vehicle.Id, vehicle => vehicle.Name);
        //              var imagesUrlRelations = await feeder.ScrappyUrlImage(vehicleNames);

        //              vehicles.ForEach(vehicle =>
        //              {
        //                  if (imagesUrlRelations.TryGetValue(vehicle.Id, out string? link))
        //                  {
        //                      vehicle.ImageUrl = link ?? string.Empty;
        //                  }
        //              });

        //              context.Vehicles.UpdateRange(vehicles);
        //              await context.SaveChangesAsync();
        //          }
        //          catch (Exception ex)
        //          {
        //              Console.WriteLine(ex.ToString());
        //              return Results.BadRequest();
        //          }

        //          return TypedResults.Ok("Vehicles Image URL feed with success.");

        //      }).WithTags("Seed")
        //        .WithOpenApi();

        //      app.MapPost("/MovieImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //      {
        //          try
        //          {
        //              var movies = context.Movies.ToList();
        //              var imagesUrlRelations = feeder.ScrappyUrlImageForMovies(movies);

            //var movies = feeder.GetMovies(filmsBase, relationMovieVehicle, relationMoviePlanet, relationMovieStarship, relationCharacterMovie);
            //var characters = feeder.GetCharacters(charactersBase, relationCharacterMovie);

        //          return TypedResults.Ok("Movies Image URL feed with success.");

        //    return infosMovies.Count != 0 ? TypedResults.Ok("TEST") : Results.NoContent();
        //}).WithTags("Seed")
        //  .WithOpenApi();

        //app.MapPost("/CharacterImageSeed", async (SqliteContext context, DataBaseFeeder feeder) =>
        //{
        //    try
        //    {
        //        var characters = context.Characters.ToList();
        //        var characterIdNames = characters.ToDictionary(character => character.Id, character => character.Name);
        //        var imagesUrlRelations = await feeder.ScrappyUrlImage(characterIdNames);

        //        characters.ForEach(character => {
        //            if (imagesUrlRelations.TryGetValue(charaScter.Id, out string? link))
        //            {
        //                character.ImageUrl = link ?? string.Empty;
        //            }
        //        });

        //        context.Characters.UpdateRange(characters);
        //        await context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return Results.BadRequest();
        //    }

        return app;
    }
}
