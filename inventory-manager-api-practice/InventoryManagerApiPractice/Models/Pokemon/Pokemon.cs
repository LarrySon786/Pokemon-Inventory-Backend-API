using System.ComponentModel.DataAnnotations;

namespace InventoryManagerApiPractice.Models;

public class Pokemon
{
    public int Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty.")]
    public required string Name { get; set; }

    public SpriteVersion Sprites { get; set; } = new();
    public List<PokemonMoveEntry> Moves { get; set; } = new();
}



