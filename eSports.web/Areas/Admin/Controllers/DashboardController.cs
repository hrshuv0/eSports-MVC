using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Analytics()
    {
        return View();
    }
}