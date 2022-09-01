using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eSports.entities.Models;

public class Tournament
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    public int GameId { get; set; }
    [ForeignKey("GameId")]
    [ValidateNever]
    public Game? Game { get; set; }

    public int? TournamentCategoryId { get; set; }
    [ForeignKey("TournamentCategoryId")]
    [ValidateNever]
    public TournamentCategory? TournamentCategory { get; set; }
    
    
    public IEnumerable<TournamentPrize>? TournamentPrizes { get; set; }
}