using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using eSports.web.Areas.Player.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.web.Areas.Player.Controllers;

[Area("Player")]
public class GameController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public GameController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        var result = _unitOfWork.Game.GetAll(includeProperties:"Category");
        
        return View(result);
    }

    // Get
    public IActionResult Details(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var game = _unitOfWork.Game.GetFirstOrDefault(c => c.Id == id, includeProperties:"Category") ?? new Game();
        var tournamentList = _unitOfWork.Tournament.GetAll(includeProperties:"TournamentCategory") ?? new List<Tournament>();
        
        GameDetailsVm gameDetails = new GameDetailsVm()
        {
            Game = game,
            TournamentList = tournamentList
        };
        
        
        

        return View(gameDetails);
    }
    
    
    



    
}