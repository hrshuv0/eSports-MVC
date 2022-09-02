using System.Diagnostics;
using eSports.dal.Repository.IRepository;
using eSports.entities.ViewModels;
using eSports.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Player.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        HomeVm homeVm = new HomeVm()
        {
            Tournaments = _unitOfWork.Tournament.GetAll(includeProperties:"Game,TournamentCategory,Prize"),
            Games = _unitOfWork.Game.GetAll(includeProperties:"Category")
        };
        
        return View(homeVm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}