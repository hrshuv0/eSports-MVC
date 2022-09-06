using System.ComponentModel.DataAnnotations;

namespace eSports.entities.Models;

public class Team
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    
    public IEnumerable<ApplicationUser>? TeamMembers { get; set; }
    
}