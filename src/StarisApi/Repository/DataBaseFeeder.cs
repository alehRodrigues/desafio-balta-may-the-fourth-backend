﻿using System.Net.Http;
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

        return infos;
    }

  
}