using System.ComponentModel.DataAnnotations;
using ApiPractice.Models;
using ApiPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controller;

[ApiController]
[Route("inventory")]
public class InventoryController : ControllerBase
{
    private readonly ProductService _productService;

    public InventoryController(ProductService productService)
    {
        _productService = productService;
    }

    // GET all products || Can filter with maxPrice variable
    [HttpGet("products")]
    public async Task<IActionResult> FetchProducts(decimal? maxPrice)
    {
        var products = await _productService.GetAllProducts(maxPrice);
        return Ok(products);
    }

    // Get Product by Id
    [HttpGet("products/{id:int}")]
    public async Task<IActionResult> FetchProductById(int id)
    {
        Product? product = await _productService.GetProductById(id);
        if (product == null) return NotFound();
        else return Ok(product);
    }

    // Post a new product
    [HttpPost("products")]
    public async Task<IActionResult> PostProduct(Product? product)
    {
        if (product == null) return BadRequest();

        var result = await _productService.CreateProduct(product);
        if (result == null) return BadRequest();

        return CreatedAtAction(
            nameof(FetchProductById),
            new { id = result.Id },
            result);
    }

    // PUT an existing product
    [HttpPut("products/{id:int}")]
    public async Task<IActionResult> PutProduct(int id, Product? product)
    {
        if (product == null)
            return BadRequest();
            
        product.Id = id;
        var result = await _productService.UpdateProduct(product);

        if (result == null) 
            return NotFound();

        return Ok(result);
    }

    // DELETE an existing product
    [HttpDelete("products/{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);

        if (result == false)
            return NotFound();

        return NoContent();
    }
}