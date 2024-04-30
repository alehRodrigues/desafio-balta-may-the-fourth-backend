using System.Text.Json;
using StarisApi.Attributes;
using StarisApi.DbContexts;
using StarisApi.Handlers;
using StarisApi.Models;

namespace StarisApi.Repository;

public class DataBaseFeederRepository<TEntity>
    where TEntity : Entity, new()
{
    private readonly SqliteContext _context;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _urlBase = "https://swapi.py4e.com/api/";
    private readonly HttpClient _client;

    public DataBaseFeederRepository(SqliteContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
        _client = _httpClientFactory.CreateClient();
    }

    public async Task<string> InsertNew<T>(List<TEntity> obj)
    {
        try
        {
            _context.Set<TEntity>().AddRange(obj);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return "Bad Request 500";
        }
        return Results.Ok("Database successfully feed.").ToString()!;
    }

    public async Task<List<JsonElement>> GetInfoFromEndpoint(string entityName)
    {
        var endpoint = DataBaseFeederHandler.GetSwapiUrlRelation(entityName);

        List<JsonElement> infos = [];

        for (var i = 0; i < endpoint.Item2; i++)
        {
            var response = await _client.GetAsync($"{_urlBase}/{endpoint.Item1}?page={i + 1}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);

            JsonElement resultProperty = bodyMessage.RootElement.GetProperty("results");

            if (resultProperty.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in resultProperty.EnumerateArray())
                {
                    infos.Add(element);
                }
            }
        }

        return infos;
    }

    public Dictionary<int, List<int>> GetRelationInfoFromJson(
        List<JsonElement> infos,
        string relationName
    )
    {
        var relationInfo = new Dictionary<int, List<int>>();
        for (int i = 0; i < infos.Count; i++)
        {
            var splitedIdUrl = infos[i].GetProperty("url").GetString()!.Split("/");
            var movieId = DataBaseFeederHandler.GetIdFromUrl(splitedIdUrl);
            var relationIds = DataBaseFeederHandler.GetUrlRelationsId(
                infos[i].GetProperty(relationName)
            );
            relationInfo.Add(movieId, relationIds);
        }
        return relationInfo;
    }

    public async Task FeedRelationsTable(List<JsonElement> infos)
    {
        var movieCharactersIds = GetRelationInfoFromJson(infos, "characters");
        var moviePlanetsIds = GetRelationInfoFromJson(infos, "planets");
        var movieStarshipsIds = GetRelationInfoFromJson(infos, "starships");
        var movieVehiclesIds = GetRelationInfoFromJson(infos, "vehicles");
        var movieCharacters = DataBaseFeederHandler.GetCharacterMovieBase(movieCharactersIds);
        var moviePlanets = DataBaseFeederHandler.GetMoviePlanetBase(moviePlanetsIds);
        var movieStarships = DataBaseFeederHandler.GetMovieStarshipBase(movieStarshipsIds);
        var movieVehicles = DataBaseFeederHandler.GetMovieVehicleBase(movieVehiclesIds);

        var movies = _context.Movies.ToList();
        var characters = _context.Characters.ToList();
        var planets = _context.Planets.ToList();
        var starships = _context.StarShips.ToList();
        var vehicles = _context.Vehicles.ToList();

        foreach (var movie in movies)
        {
            movie.Characters = movieCharacters.Where(x => x.MovieId == movie.Id).ToList();
            movie.Planets = moviePlanets.Where(x => x.MovieId == movie.Id).ToList();
            movie.Starships = movieStarships.Where(x => x.MovieId == movie.Id).ToList();
            movie.Vehicles = movieVehicles.Where(x => x.MovieId == movie.Id).ToList();
        }
        foreach (var character in characters)
        {
            character.Movies = movieCharacters.Where(x => x.CharacterId == character.Id).ToList();
        }
        foreach (var planet in planets)
        {
            planet.Movies = moviePlanets.Where(x => x.PlanetId == planet.Id).ToList();
        }
        foreach (var starship in starships)
        {
            starship.Movies = movieStarships.Where(x => x.StarshipId == starship.Id).ToList();
        }
        foreach (var vehicle in vehicles)
        {
            vehicle.Movies = movieVehicles.Where(x => x.VehicleId == vehicle.Id).ToList();
        }

        _context.CharacterMovies.AddRange(movieCharacters);
        _context.MoviesPlanets.AddRange(moviePlanets);
        _context.MoviesStarships.AddRange(movieStarships);
        _context.MoviesVehicles.AddRange(movieVehicles);
        _context.Movies.UpdateRange(movies);
        _context.Characters.UpdateRange(characters);
        _context.Planets.UpdateRange(planets);
        _context.StarShips.UpdateRange(starships);
        _context.Vehicles.UpdateRange(vehicles);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetEntityBase<T>(List<JsonElement> infos)
    {
        var entities = new List<TEntity>();
        foreach (var info in infos)
        {
            var entity = new TEntity().ConvertFromJson<TEntity>(info);
            if (!Attribute.IsDefined(typeof(TEntity), typeof(NotProcessImageAttribute)))
            {
                entity.ImageUrl = await ScrappyUrlImage(entity.ImageUrl);

                string[] parts;
                if (entity.ImageUrl.Contains(".png"))
                {
                    parts = entity.ImageUrl.Split(new[] { ".png" }, StringSplitOptions.None);
                    entity.ImageUrl = parts[0] + ".png";
                }
                else
                {
                    parts = entity.ImageUrl.Split(new[] { ".jpg" }, StringSplitOptions.None);
                    entity.ImageUrl = parts[0] + ".jpg";
                }
            }

            entities.Add(entity);
        }
        await Task.CompletedTask;
        return entities;
    }

    public async Task<string> ScrappyUrlImage(string url)
    {
        string htmlContent = await _client.GetStringAsync(url);
        return DataBaseFeederHandler.ExtractImageUrl(htmlContent);
    }
}
