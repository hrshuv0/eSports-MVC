using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Controllers;

public class GamesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public GamesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Game model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Game.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    
}