﻿using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Player.Controllers;

[Area("Player")]
public class ClansController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}