using System.ComponentModel.DataAnnotations;

namespace eSports.web.Areas.Identity.Models;

public class RegisterVm
{
    [Required(ErrorMessage = "user name is required")]
    [Display(Name = "User Name")]
    public string? UserName { get; set; }

    public string? Email { get; set; }

    [Required(ErrorMessage = "Game Id is required")]
    public string? GameId { get; set; }

    [Required(ErrorMessage = "password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "password didn't password")]
    public string? ConfirmPassword { get; set; }
}