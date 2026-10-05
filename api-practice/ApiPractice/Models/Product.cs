using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Name must be between 2 and 50 characters")]
    public string Name { get; set; } = "";

    [Range(0.01, 100000,
        ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Range(0, 100000,
        ErrorMessage = "Cost cannot be negative")]
    public decimal Cost { get; set; }

    [Range(0, int.MaxValue,
        ErrorMessage = "On hand cannot be negative")]
    public int OnHand { get; set; }

    [Range(0, int.MaxValue,
        ErrorMessage = "Desired on hand cannot be negative")]
    public int DesiredOnHand { get; set; }
}