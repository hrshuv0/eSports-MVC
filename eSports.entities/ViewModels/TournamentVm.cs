using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.entities.ViewModels;

public class TournamentVm
{
    public Tournament? Tournament { get; set; }
    
    public IEnumerable<SelectListItem>? PrizeList { get; set; }
    public IEnumerable<SelectListItem>? GameList { get; set; }
    public IEnumerable<SelectListItem>? CategoryList { get; set; }

    
}