using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.entities.ViewModels;

public class TournamentPrizeVm
{
    [ValidateNever]
    public IEnumerable<SelectListItem>? TournamentList { get; set; }
    
    [ValidateNever]
    public IEnumerable<SelectListItem>? PrizeList { get; set; }

}