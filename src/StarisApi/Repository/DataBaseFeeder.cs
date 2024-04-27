using StarisApi.Models.Characters;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.Movies;
using StarisApi.Models.MoviesPlanet;
using StarisApi.Models.MoviesStarships;
using StarisApi.Models.MoviesVehicles;
using StarisApi.Models.Planets;
using StarisApi.Models.StarShips;
using StarisApi.Models.Vehicles;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

namespace StarisApi.Repository;

public class DataBaseFeeder
{
    private readonly IHttpClientFactory _httpClientFactory;
    private string _url = "https://swapi.py4e.com/api/";
    private readonly HttpClient client;

    public DataBaseFeeder(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        client = _httpClientFactory.CreateClient();
    }

    public async Task<List<JsonElement>> GetInfoFromPeopleEndpoint()
    {
        var endpoint = "people/";

        List<JsonElement> infos = [];

        for (var i = 0; i < 9; i++)
        {
            var response = await client.GetAsync($"{_url}/{endpoint}?page={i + 1}");
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

    public async Task<List<JsonElement>> GetInfoFromPlanetsEndpoint()
    {
        var endpoint = "planets/";

        List<JsonElement> infos = [];

        for (var i = 0; i < 7; i++)
        {
            var response = await client.GetAsync($"{_url}/{endpoint}?page={i + 1}");
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

    public async Task<List<JsonElement>> GetInfoFromMoviesEndpoint()
    {
        var endpoint = "films/";
        List<JsonElement> infos = [];
        var response = await client.GetAsync($"{_url}/{endpoint}");
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

        return infos;
    }

    public async Task<List<JsonElement>> GetInfoFromStarshiptEndpoint()
    {
        var endpoint = "starships/";
        List<JsonElement> infos = [];

        for (var i = 0; i < 4; i++)
        {
            var response = await client.GetAsync($"{_url}/{endpoint}?page={i + 1}");
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

    public async Task<List<JsonElement>> GetInfoFromVehicleEndpoint()
    {
        var endpoint = "vehicles/";
        List<JsonElement> infos = [];

        for (var i = 0; i < 4; i++)
        {
            var response = await client.GetAsync($"{_url}/{endpoint}?page={i + 1}");
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

    public List<Movie> GetMoviesBase(List<JsonElement> infos)
    {
        var movies = new List<Movie>();
        foreach (var info in infos)
        {
            var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
            var movieCharacterIds = GetUrlRelationsId(info.GetProperty("characters"));
            var moviePlanetIds = GetUrlRelationsId(info.GetProperty("planets"));
            var movieStarshipIds = GetUrlRelationsId(info.GetProperty("starships"));
            var movieVehicleIds = GetUrlRelationsId(info.GetProperty("vehicles"));
            var id = GetIdFromUrl(splitedIdUrl);

            var movie = new Movie
            {
                Id = id,
                Title = info.GetProperty("title").GetString()!,
                Episode = info.GetProperty("episode_id").GetString()!,
                OpeningCrawl = info.GetProperty("opening_crawl").GetString()!,
                Director = info.GetProperty("director").GetString()!,
                Producer = info.GetProperty("producer").GetString()!,
                ReleaseDate = info.GetProperty("release_date").GetString()!,
                Characters = GetCharacterMovieBase(movieCharacterIds, id),
                Planets = GetMoviePlanetBase(moviePlanetIds, id),
                Starships = GetMovieStarshipBase(movieStarshipIds, id),
                Vehicles = GetMovieVehicleBase(movieVehicleIds, id),
            };
            movies.Add(movie);
        }

        return movies;
    }

    public List<Character> GetCharactersBase(List<JsonElement> infos)
    {
        var characters = new List<Character>();
        foreach (var info in infos)
        {
            var splitIdUrl = info.GetProperty("url").GetString()!.Split("/");
            var splitHomeUrl = info.GetProperty("homeworld").GetString()!.Split("/");
            var splitMoviesUrl = GetUrlRelationsId(info.GetProperty("films"));
            var id = GetIdFromUrl(splitIdUrl);
            //var movie = filmsBase.FirstOrDefault(x => x.Id == homeId);

            var character = new Character
            {
                Id = id,
                Name = info.GetProperty("name").GetString()!,
                Height = info.GetProperty("height").GetString()!,
                Mass = info.GetProperty("mass").GetString()!,
                HairColor = info.GetProperty("hair_color").GetString()!,
                SkinColor = info.GetProperty("skin_color").GetString()!,
                EyeColor = info.GetProperty("eye_color").GetString()!,
                BirthYear = info.GetProperty("birth_year").GetString()!,
                Gender = info.GetProperty("gender").GetString()!,
                PlanetId = GetIdFromUrl(splitHomeUrl),
                Movies = GetCharacterMovieBase(splitMoviesUrl, id)
                //Movies = info.GetProperty("films").EnumerateArray()
                //             .Select(movie => GetMovies(movie)).ToList()
                //Movies = new List<CharacterMovie>
                //    {
                //        new CharacterMovie
                //        {
                //            Movie = movie!
                //        }
                //    }
            };

            characters.Add(character);
        }

        return characters;
    }

    public List<Planet> GetPlanetsBase(List<JsonElement> infos)
    {
        var planets = new List<Planet>();

        foreach (var info in infos)
        {
            var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
            var id = GetIdFromUrl(splitedIdUrl);
            var splitMoviesUrl = GetUrlRelationsId(info.GetProperty("films"));
            var splitCharactersUrl = GetUrlRelationsId(info.GetProperty("residents"));

            var planet = new Planet
            {
                Id = id,
                Name = info.GetProperty("name").GetString()!,
                Diameter = info.GetProperty("diameter").GetString()!,
                RotationSpeed = info.GetProperty("rotation_period").GetString()!,
                OrbitalPeriod = info.GetProperty("orbital_period").GetString()!,
                Gravity = info.GetProperty("gravity").GetString()!,
                Population = info.GetProperty("population").GetString()!,
                Climate = info.GetProperty("climate").GetString()!,
                Terrain = info.GetProperty("terrain").GetString()!,
                SurfaceWater = info.GetProperty("surface_water").GetString()!,
                Characters = GetPlanetCharactersBase(splitCharactersUrl, id),
                Movies = GetMoviePlanetBase(splitMoviesUrl, id)
            };
            planets.Add(planet);
        }

        return planets;
    }

    public List<Starship> GetStarshipsBase(List<JsonElement> infos)
    {
        var starships = new List<Starship>();

        foreach (var info in infos)
        {
            var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
            var id = GetIdFromUrl(splitedIdUrl);

            var starship = new Starship
            {
                Id = id,
                Model = info.GetProperty("model").GetString()!,
                Name = info.GetProperty("name").GetString()!,
                StarshipClass = info.GetProperty("starship_class").GetString()!,
                Manufacturer = info.GetProperty("manufacturer").GetString()!,
                CostInCredits = info.GetProperty("cost_in_credits").GetString()!,
                Lenght = info.GetProperty("length").GetString()!,
                Crew = info.GetProperty("crew").GetString()!,
                Passengers = info.GetProperty("passengers").GetString()!,
                MaxAtmospheringSpeed = info.GetProperty("max_atmosphering_speed").GetString()!,
                HyperDriveRating = info.GetProperty("hyperdrive_rating").GetString()!,
                Megalights = info.GetProperty("MGLT").GetString()!,
                CargoCapacity = info.GetProperty("cargo_capacity").GetString()!,
                Consumables = info.GetProperty("consumables").GetString()!
            };
            starships.Add(starship);
        }

        return starships;
    }

    public List<Vehicle> GetVehiclesBase(List<JsonElement> infos)
    {
        var vehicles = new List<Vehicle>();

        foreach (var info in infos)
        {
            var splitedIdUrl = info.GetProperty("url").GetString()!.Split("/");
            var id = GetIdFromUrl(splitedIdUrl);
            var vehicle = new Vehicle
            {
                Id = id,
                Model = info.GetProperty("model").GetString()!,
                Name = info.GetProperty("name").GetString()!,
                VehicleClass = info.GetProperty("vehicle_class").GetString()!,
                Manufacturer = info.GetProperty("manufacturer").GetString()!,
                CostInCredits = info.GetProperty("cost_in_credits").GetString()!,
                Lenght = info.GetProperty("length").GetString()!,
                Crew = info.GetProperty("crew").GetString()!,
                Passengers = info.GetProperty("passengers").GetString()!,
                MaxAtmospheringSpeed = info.GetProperty("max_atmosphering_speed").GetString()!,
                CargoCapacity = info.GetProperty("cargo_capacity").GetString()!,
                Consumables = info.GetProperty("consumables").GetString()!
            };
            vehicles.Add(vehicle);
        }

        return vehicles;
    }

    public List<Character> GetPlanetCharactersBase(List<int> ids, int id)
    {
        var planetCharacters = new List<Character>();

        for (int i = 0; i < ids.Count; i++)
        {
            var relationship = new Character
            {
                Id = ids[i],
            };
            planetCharacters.Add(relationship);
        }

        return planetCharacters;
    }
    public List<CharacterMovie> GetCharacterMovieBase(List<int> ids, int id)
    {
        var characterMovies = new List<CharacterMovie>();

        for (int i = 0; i < ids.Count; i++)
        {
            var relationship = new CharacterMovie
            {
                CharacterId = ids[i],
                MovieId = id,
            };
            characterMovies.Add(relationship);
        }

        return characterMovies;
    }

    public List<MoviePlanet> GetMoviePlanetBase(List<int> ids, int id)
    {
        var moviePlanets = new List<MoviePlanet>();

        for (int i = 0; i < ids.Count; i++)
        {
            var relationship = new MoviePlanet
            {
                PlanetId = ids[i],
                MovieId = id,
            };
            moviePlanets.Add(relationship);
        }

        return moviePlanets;
    }

    public List<MovieStarship> GetMovieStarshipBase(List<int> ids, int id) 
    {
        var movieStarship = new List<MovieStarship>();

        for (int i = 0; i < ids.Count; i++)
        {
            var relationship = new MovieStarship
            {
                StarshipId = ids[i],
                MovieId = id,
            };
            movieStarship.Add(relationship);
        }

        return movieStarship;
    }

    public List<MovieVehicle> GetMovieVehicleBase(List<int> ids, int id)
    {
        var movieStarship = new List<MovieVehicle>();

        for (int i = 0; i < ids.Count; i++)
        {
            var relationship = new MovieVehicle
            {
                VehicleId = ids[i],
                MovieId = id,
            };
            movieStarship.Add(relationship);
        }

        return movieStarship;
    }

    public List<CharacterMovie> GetCharacterMovieRelation(List<Movie> movies, List<Character> characters)
    {
        Dictionary<int, List<CharacterMovie>> characterMovieDictionary = [];
        var characterMovies = new List<CharacterMovie>();
        var index = 0;

        foreach (var movie in movies)
        {
            characterMovieDictionary.Add(movie.Id, [.. movie.Characters]);
        }

        foreach (var relation in characterMovieDictionary)
        {
            var characterIds = relation.Value.Select(r => r.CharacterId).ToList();
            var relatedCharacters = characters.Where(v => characterIds.Contains(v.Id)).ToList();
            var movie = movies.Find(x => relation.Key == x.Id);

            foreach (var character in relatedCharacters)
            {
                if (movie == null)
                {
                    continue;
                }
                index++;
                var relationship = new CharacterMovie
                {
                    Id = index,
                    MovieId = relation.Key,
                    //Movie = movie,
                    CharacterId = character.Id,
                    //Character = character
                };
                characterMovies.Add(relationship);
            }
        }

        return characterMovies;
    }

    public List<MovieVehicle> GetMovieVehicleRelation(List<Movie> movies, List<Vehicle> vehicles)
    {
        Dictionary<int, List<MovieVehicle>> movieCharacterDictionary = [];
        var movieVehicles = new List<MovieVehicle>();
        var index = 0;

        foreach (var movie in movies)
        {
            movieCharacterDictionary.Add(movie.Id, [.. movie.Vehicles]);
        }

        foreach (var relation in movieCharacterDictionary)
        {
            var vehicleIds = relation.Value.Select(r => r.VehicleId).ToList();
            var relatedVehicles = vehicles.Where(v => vehicleIds.Contains(v.Id)).ToList();
            var movie = movies.Find(x => relation.Key == x.Id);

            foreach (var vehicle in relatedVehicles)
            {
                if (movie == null)
                {
                    continue;
                }

                index++;
                var relationship = new MovieVehicle
                {
                    Id = index,
                    MovieId = relation.Key,
                    //Movie = movie,
                    VehicleId = vehicle.Id,
                    //Vehicle = vehicle
                };
                movieVehicles.Add(relationship);
            }
        }

        return movieVehicles;
    }

    public List<MovieStarship> GetMovieStarshipRelation(List<Movie> movies, List<Starship> starships)
    {
        Dictionary<int, List<MovieStarship>> movieStarshipDictionary = [];
        var movieStarShip = new List<MovieStarship>();
        var index = 0;

        foreach (var movie in movies)
        {
            movieStarshipDictionary.Add(movie.Id, [.. movie.Starships]);
        }

        foreach (var relation in movieStarshipDictionary)
        {
            var starshipIds = relation.Value.Select(r => r.StarshipId).ToList();
            var relatedStarship = starships.Where(v => starshipIds.Contains(v.Id)).ToList();
            var movie = movies.Find(x => relation.Key == x.Id);

            foreach (var starShip in relatedStarship)
            {
                if (movie == null)
                {
                    continue;
                }

                index++;
                var relationship = new MovieStarship
                {
                    Id = index,
                    MovieId = relation.Key,
                    //Movie = movie,
                    StarshipId = starShip.Id,
                    //Starship = starShip
                };
                movieStarShip.Add(relationship);
            }
        }

        return movieStarShip;
    }

    public List<MoviePlanet> GetMoviePlanetRelation(List<Movie> movies, List<Planet> planets)
    {
        Dictionary<int, List<MoviePlanet>> moviePlanetDictionary = [];
        var moviePlanet = new List<MoviePlanet>();
        var index = 0;

        foreach (var movie in movies)
        {
            moviePlanetDictionary.Add(movie.Id, [.. movie.Planets]);
        }

        foreach (var relation in moviePlanetDictionary)
        {
            var planetIds = relation.Value.Select(r => r.PlanetId).ToList();
            var relatedPlanet = planets.Where(v => planetIds.Contains(v.Id)).ToList();
            var movie = movies.Find(x => relation.Key == x.Id);

            foreach (var planet in relatedPlanet)
            {
                if(movie == null)
                {
                    continue;
                }
                index++;
                var relationship = new MoviePlanet
                {
                    Id = index,
                    MovieId = relation.Key,
                    //Movie = movie,
                    PlanetId = planet.Id,
                    //Planet = planet
                };
                moviePlanet.Add(relationship);
            }
        }

        return moviePlanet;
    }

    public List<Movie> GetMovies(List<Movie> filmsBase,
            List<MovieVehicle> relationMovieVehicle,
            List<MoviePlanet> relationMoviePlanet,
            List<MovieStarship> relationMovieStarship,
            List<CharacterMovie> relationCharacterMovie)
    {
        foreach (Movie movie in filmsBase)
        {
            movie.Vehicles = relationMovieVehicle.Where(x => x.MovieId == movie.Id).ToList();
            movie.Starships = relationMovieStarship.Where(x => x.MovieId == movie.Id).ToList();
            movie.Planets = relationMoviePlanet.Where(x => x.MovieId == movie.Id).ToList();
            movie.Characters = relationCharacterMovie.Where(x => x.MovieId == movie.Id).ToList();
        }

        return filmsBase;
    }

    public List<Character> GetCharacters(List<Character> characterBase, List<CharacterMovie> relationCharacterMovie)
    {
        foreach(Character character in characterBase)
        {
            character.Movies = relationCharacterMovie.Where(x => x.CharacterId == character.Id).ToList();
        }

        return characterBase;
    }

    public List<int> GetUrlRelationsId(JsonElement infos)
    {
        List<int> relationIds = [];
        if (infos.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement movieCharacterUrlElement in infos.EnumerateArray())
            {
                var characterUrl = movieCharacterUrlElement.GetString()!.Split("/");
                if (characterUrl != null)
                {
                    relationIds.Add(GetIdFromUrl(characterUrl));
                }
            }
        }

        return relationIds;
    }

    public int GetIdFromUrl(string[] url)
    {
        return int.Parse(url[^2]);
    }

    public async Task<Dictionary<int, string>> ScrappyUrlImage(Dictionary<int, string> entityNames)
    {
        var urls = MountUrlString(entityNames);
        var entityUrlImagesRelation = new Dictionary<int, string>();

        foreach (var url in urls)
        {
            string htmlContent = await client.GetStringAsync(url.Value);
            entityUrlImagesRelation.Add(url.Key, ExtractImageUrl(htmlContent));
        }

        return entityUrlImagesRelation;
    }

    public List<Movie> ScrappyUrlImageForMovies(List<Movie> movies)
    {
        List<string> imageUrls = [
                                    "https://lumiere-a.akamaihd.net/v1/images/EP1-IA-99993-RESIZED_f9ae99b6.jpeg",
                                    "https://lumiere-a.akamaihd.net/v1/images/EP2-IA-69221-RESIZED_1e8e0971.jpeg",
                                    "https://lumiere-a.akamaihd.net/v1/images/image_ff356cdb.jpeg",
                                    "https://lumiere-a.akamaihd.net/v1/images/EP4_POS_2_D-RESIZED_f977074a.jpeg",
                                    "https://lumiere-a.akamaihd.net/v1/images/image_ca7910bd.jpeg",
                                    "https://lumiere-a.akamaihd.net/v1/images/EP6_POS_21_R-RESIZED_2873dc04.jpeg",
                                    "https://lumiere-a.akamaihd.net/v1/images/avco_payoff_1-sht_v7_lg_32e68793.jpeg"
                                  ];
        movies = [.. movies.OrderBy(x => x.Episode)];

        for (int i = 0; i < movies.Count; i++)
        {
            movies[i].ImageUrl = imageUrls[i];
        }

        return movies;
    }

    public Dictionary<int, string> MountUrlString(Dictionary<int, string> entityNames)
    {
        string urlBase = "https://starwars.fandom.com/wiki/";
        
        return entityNames.ToDictionary(
            kvp => kvp.Key,
            kvp => $"{urlBase}{kvp.Value.Replace(" ", "_")}"
        );
    }

    string ExtractImageUrl(string htmlContent)
    {
        int startIndex = htmlContent.IndexOf("<a", StringComparison.OrdinalIgnoreCase);
        string resultUrl = string.Empty;
        
        while (startIndex != -1)
        {
            if (htmlContent.IndexOf("class=\"image image-thumbnail\"", startIndex, StringComparison.OrdinalIgnoreCase) != -1)
            {
                int hrefIndex = htmlContent.IndexOf("href=\"", startIndex, StringComparison.OrdinalIgnoreCase);
                if (hrefIndex != -1)
                {
                    int endIndex = htmlContent.IndexOf("\"", hrefIndex + 6, StringComparison.OrdinalIgnoreCase);
                    if (endIndex != -1)
                    {
                        resultUrl = htmlContent.Substring(hrefIndex + 6, endIndex - hrefIndex - 6);
                    }
                }
            }

            startIndex = htmlContent.IndexOf("<a", startIndex + 1, StringComparison.OrdinalIgnoreCase);
        }

        return resultUrl;
    }
}
