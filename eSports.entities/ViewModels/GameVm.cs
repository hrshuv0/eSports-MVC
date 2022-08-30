using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.entities.ViewModels;

public class GameVm
{
    public Game Game { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem>? CategoryList { get; set; }
}