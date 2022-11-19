using eSports.dal.Repository.IRepository;
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
}