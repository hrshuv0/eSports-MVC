using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eSports.entities.Models;

public class Tournament
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [Display(Name="Tournament Name")]
    public string? Name { get; set; }

    [Display(Name = "Game")]
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    [ValidateNever]
    public Game? Game { get; set; }

    [Required] 
    public int TotalMatch { get; set; } = 3;

    [Display(Name = "Start Time")]
    public DateTime? StartTime { get; set; }
    [Display(Name = "End Time")]
    public DateTime? EndTime { get; set; }

    [Display(Name = "Tournament Category")]
    public int? TournamentCategoryId { get; set; }
    [ForeignKey("TournamentCategoryId")]
    [ValidateNever]
    public TournamentCategory? TournamentCategory { get; set; }

    public int? PrizeId { get; set; }
    [ForeignKey("PrizeId")]
    [ValidateNever]
    public Prize? Prize { get; set; }

    public decimal? PrizePool { get; set; }
    
}