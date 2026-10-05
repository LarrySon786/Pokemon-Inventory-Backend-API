using System.ComponentModel.DataAnnotations;
using InventoryManagerApiPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerApiPractice.Services;

public class ProductApiService
{
    private readonly HttpClient _http;

    public ProductApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<Product?> CreateProduct(Product product)
    {
        var response = await _http.PostAsJsonAsync("inventory/products", product);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<Product>();

        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            if (problem != null)
            {
                var messages = problem.Errors.SelectMany(x => x.Value);
                throw new ValidationException(string.Join(Environment.NewLine, messages));
            }
        }
        return null;
    }


}