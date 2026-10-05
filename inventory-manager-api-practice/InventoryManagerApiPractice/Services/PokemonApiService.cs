
using InventoryManagerApiPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerApiPractice.Services;

public class PokemonApiService
{
    private readonly HttpClient _http;

    public PokemonApiService(HttpClient http)
    {
        _http = http;
    }

    // GET by name
    public async Task<Pokemon> GetByName(string name)
    {
        var response = await _http.GetAsync($"pokemon/{name}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Could not get pokemon.");

        var data = await response.Content.ReadFromJsonAsync<Pokemon>();

        if (data == null)
            throw new Exception("Could not load pokemon data.");

        return data;
    }




}
