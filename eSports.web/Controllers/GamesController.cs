using eSports.dal.Data;
using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Controllers;

public class GamesController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public GamesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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

        _dbContext.Games!.Add(model);
        _dbContext.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
    
    
}