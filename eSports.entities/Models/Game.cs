using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eSports.entities.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [StringLength(100)]
    public string? ImageUrl { get; set; }
    
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public Category? Category { get; set; }

}