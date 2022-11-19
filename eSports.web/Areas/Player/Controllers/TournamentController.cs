using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.web.Areas.Player.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Player.Controllers;

[Area("Player")]
public class TournamentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TournamentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        var tournamentList = _unitOfWork.Tournament.GetAll(includeProperties:"Game,TournamentCategory,Prize");
        
        return View(tournamentList);
    }
    
    public IActionResult Details(int? id)
    {
        var tournament = _unitOfWork.Tournament.GetFirstOrDefault(t => t.Id == id, includeProperties:"Game,TournamentCategory,Prize") ?? new Tournament();
        var tournamentList = _unitOfWork.Tournament.GetAll(includeProperties:"Game,TournamentCategory,Prize") ?? new List<Tournament>();

        var tournamentDetails = new TournamentDetailsVm()
        {
            Tournament = tournament,
            TournamentList = tournamentList

        };

        return View(tournamentDetails);
    }
    
    
}