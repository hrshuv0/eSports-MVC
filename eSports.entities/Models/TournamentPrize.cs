using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eSports.entities.Models;

public class TournamentPrize
{
    public int Id { get; set; }

    public int? TournamentId { get; set; }
    [ForeignKey("TournamentId")]
    [ValidateNever]
    public Tournament? Tournament { get; set; }

    public int? PrizeId { get; set; }
    [ForeignKey("PrizeId")]
    [ValidateNever]
    public Prize? Prize { get; set; }
}