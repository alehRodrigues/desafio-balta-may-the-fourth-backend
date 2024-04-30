using System.Text.Json;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.MoviesPlanet;
using StarisApi.Models.MoviesStarships;
using StarisApi.Models.MoviesVehicles;

namespace StarisApi.Handlers;

public static class DataBaseFeederHandler
{
    public static List<int> GetUrlRelationsId(JsonElement infos)
    {
        List<int> relationIds = [];
        if (infos.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement urlElement in infos.EnumerateArray())
            {
                var relationUrl = urlElement.GetString()!.Split("/");
                if (relationUrl != null)
                {
                    relationIds.Add(GetIdFromUrl(relationUrl));
                }
            }
        }

        return relationIds;
    }

    public static int GetIdFromUrl(string[] url)
    {
        return int.Parse(url[^2]);
    }

    public static (string, int) GetSwapiUrlRelation(string entityName)
    {
        Dictionary<string, (string Endpoint, int Limit)> mapEntity =
            new()
            {
                { "Character", ("people/", 9) },
                { "Planet", ("planets/", 7) },
                { "Vehicle", ("vehicles/", 4) },
                { "Starship", ("starships/", 4) },
                { "Movie", ("films/", 1) }
            };

        if (mapEntity.TryGetValue(entityName, out var entityInfo))
        {
            return entityInfo;
        }

        throw new ArgumentException($"Entity name '{entityName}' is not supported.");
    }

    public static string StringNamesFixer(string name)
    {
        Dictionary<string, string> fixRelation =
            new()
            {
                { "Beru Whitesun lars", "Beru Whitesun Lars" },
                { "Wicket Systri Warrick", "Wicket Wystri Warrick" },
                { "Ayla Secura", "Aayla Secura" },
                { "Ratts Tyerel", "Ratts Tyerell" },
                { "Sand Crawler", "Sandcrawler" },
                { "Zephyr-G swoop bike", "Zephyr-G swoop" }
            };

        if (fixRelation.TryGetValue(name, out string? value))
        {
            return value;
        }

        return name;
    }

    public static string StringImgUrlFixer(string url)
    {
        Dictionary<string, string> fixRelation =
            new()
            {
                { "Corporate Alliance tank droid", "NR-N99_Persuader-class_droid_enforcer" },
                { "Republic Assault ship", "Acclamator-class_transgalactic_military_assault_ship" },
                { "arc-170", "Aggressive_ReConnaissance-170_starfighter" },
                { "Banking clan frigte", "Munificent-class_star_frigate" },
                { "TIE bomber", "TIE/sa_bomber" },
                { "Aleen Minor", "Aleen_Minor/Legends" },
                { "Kalee", "Kalee/Legends" },
                { "Star Destroyer", "Imperial_II-class_Star_Destroyer" },
                { "X-wing", "X-wing_starfighter" },
                { "A-wing", "A-wing_starfighter" },
                { "Jedi starfighter", "Delta-7_Aethersprite-class_light_interceptor" },
                { "V-wing", "Alpha-3_Nimbus-class_V-wing_starfighter" },
            };

        if (fixRelation.TryGetValue(url, out string? value))
        {
            return value;
        }

        return url;
    }

    public static List<MoviePlanet> GetMoviePlanetBase(Dictionary<int, List<int>> relationIds)
    {
        var moviePlanets = new List<MoviePlanet>();

        foreach (var ids in relationIds)
        {
            var relationship = new MoviePlanet();
            foreach (var planetId in ids.Value)
            {
                moviePlanets.Add(relationship.MountRelation(ids.Key, planetId));
            }
        }

        return moviePlanets;
    }

    public static List<MovieStarship> GetMovieStarshipBase(Dictionary<int, List<int>> relationIds)
    {
        var movieStarship = new List<MovieStarship>();

        foreach (var ids in relationIds)
        {
            var relationship = new MovieStarship();
            foreach (var planetId in ids.Value)
            {
                movieStarship.Add(relationship.MountRelation(ids.Key, planetId));
            }
        }

        return movieStarship;
    }

    public static List<MovieVehicle> GetMovieVehicleBase(Dictionary<int, List<int>> relationIds)
    {
        var movieVehicle = new List<MovieVehicle>();

        foreach (var ids in relationIds)
        {
            var relationship = new MovieVehicle();
            foreach (var planetId in ids.Value)
            {
                movieVehicle.Add(relationship.MountRelation(ids.Key, planetId));
            }
        }

        return movieVehicle;
    }

    public static List<CharacterMovie> GetCharacterMovieBase(Dictionary<int, List<int>> relationIds)
    {
        var characterMovie = new List<CharacterMovie>();

        foreach (var ids in relationIds)
        {
            var relationship = new CharacterMovie();
            foreach (var planetId in ids.Value)
            {
                characterMovie.Add(relationship.MountRelation(ids.Key, planetId));
            }
        }

        return characterMovie;
    }

    public static string ExtractImageUrl(string htmlContent)
    {
        int startIndex = htmlContent.IndexOf("<a", StringComparison.OrdinalIgnoreCase);
        string resultUrl = string.Empty;

        while (startIndex != -1)
        {
            if (
                htmlContent.IndexOf(
                    "class=\"image image-thumbnail\"",
                    startIndex,
                    StringComparison.OrdinalIgnoreCase
                ) != -1
            )
            {
                int hrefIndex = htmlContent.IndexOf(
                    "href=\"",
                    startIndex,
                    StringComparison.OrdinalIgnoreCase
                );
                if (hrefIndex != -1)
                {
                    int endIndex = htmlContent.IndexOf(
                        "\"",
                        hrefIndex + 6,
                        StringComparison.OrdinalIgnoreCase
                    );
                    if (endIndex != -1)
                    {
                        resultUrl = htmlContent.Substring(hrefIndex + 6, endIndex - hrefIndex - 6);
                    }
                }
            }

            startIndex = htmlContent.IndexOf(
                "<a",
                startIndex + 1,
                StringComparison.OrdinalIgnoreCase
            );
        }

        return resultUrl;
    }

    public static string ScrappyUrlImageForMovies(int episode)
    {
        List<string> imageUrls =
        [
            "https://lumiere-a.akamaihd.net/v1/images/EP1-IA-99993-RESIZED_f9ae99b6.jpeg",
            "https://lumiere-a.akamaihd.net/v1/images/EP2-IA-69221-RESIZED_1e8e0971.jpeg",
            "https://lumiere-a.akamaihd.net/v1/images/image_ff356cdb.jpeg",
            "https://lumiere-a.akamaihd.net/v1/images/EP4_POS_2_D-RESIZED_f977074a.jpeg",
            "https://lumiere-a.akamaihd.net/v1/images/image_ca7910bd.jpeg",
            "https://lumiere-a.akamaihd.net/v1/images/EP6_POS_21_R-RESIZED_2873dc04.jpeg",
            "https://lumiere-a.akamaihd.net/v1/images/avco_payoff_1-sht_v7_lg_32e68793.jpeg"
        ];

        return imageUrls[episode - 1];
    }
}
