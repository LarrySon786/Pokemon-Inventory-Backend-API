using System.ComponentModel.DataAnnotations;

namespace InventoryManagerApiPractice.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    // Properties
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Cost { get; set; } = 0;
    public int OnHand { get; set; } = 0;
    public int DesiredOnHand { get; set; } = 0;
    public string DisplayPrice => string.Format("{0:C}", Price);
}