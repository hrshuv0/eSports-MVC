using System.ComponentModel.DataAnnotations;

namespace eSports.entities.Models;

public class TournamentCategory
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    
}