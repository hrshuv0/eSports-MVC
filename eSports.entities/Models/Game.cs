using System.ComponentModel.DataAnnotations;

namespace eSports.entities.Models;

public class Game
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
}