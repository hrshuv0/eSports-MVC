using System.ComponentModel.DataAnnotations;

namespace eSports.entities.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string? Name { get; set; }

    public IEnumerable<Game>? Games { get; set; }
}