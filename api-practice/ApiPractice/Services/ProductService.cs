using System.ComponentModel.DataAnnotations;
using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Services;

public class ProductService
{
    private readonly ProjectDbConnection _context;

    public ProductService(ProjectDbConnection context)
    {
        _context = context;
    }

    // GET ALL
    public async Task<List<Product>> GetAllProducts(decimal? maxPrice)
    {
        var products = new List<Product>();

        if (maxPrice.HasValue)
        {
            products = await _context.ProductDb.Where(x => x.Price <= maxPrice).ToListAsync();
        }
        else
        {
            products = await _context.ProductDb.ToListAsync();
        }

        return products;
    }

    // Get by Id
    public async Task<Product?> GetProductById(int id)
    {
        return await _context.ProductDb.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Create new product
    public async Task<Product?> CreateProduct(Product product)
    {
        // var errors = ServerSideValidation(product);
        // if (errors.Count() > 0)
        // {
        //     string errorMessage = string.Empty;
        //     foreach (var error in errors)
        //     {
        //         errorMessage += $"{error.ErrorMessage}. \n";
        //     }
        //     throw new ValidationException(errorMessage);
        // }
            
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    // Update existing product
    public async Task<Product?> UpdateProduct(Product product)
    {
        var existing = await GetProductById(product.Id);
        if (existing == null) return null;

        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Cost = product.Cost;
        existing.DesiredOnHand = product.DesiredOnHand;
        existing.OnHand = product.OnHand;

        await _context.SaveChangesAsync();
        return existing;
    }

    // Delete existing product
    public async Task<bool> DeleteProduct(int id)
    {
        var result = await _context.ProductDb.Where(x => x.Id == id).ExecuteDeleteAsync();
        if (result > 0) return true;
        else return false;
    }

    private List<ValidationResult> ServerSideValidation(Product product)
    {
        var errors = new List<ValidationResult>();

        var context = new ValidationContext(product);
        Validator.TryValidateObject(product, context, errors, validateAllProperties: true);

        return errors;
    }

}