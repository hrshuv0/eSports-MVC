using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Player.Controllers;

[Area("Player")]
public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}