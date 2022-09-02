using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.web.Areas.Admin.Controllers;

public class TournamentsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public TournamentsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var result = _unitOfWork.Tournament.GetAll(includeProperties:"Game,TournamentCategory");
        
        return View(result);
    }
    
    public IActionResult Create()
    {
        TournamentVm tournamentVm = new TournamentVm()
        {
            Tournament = new Tournament(),
            PrizeList = _unitOfWork.Prize.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.PlaceName,
                Value = c.Id.ToString()
            }),
            GameList = _unitOfWork.Game.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }),
            CategoryList = _unitOfWork.TournamentCategory.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }),
            

        };
        
        return View(tournamentVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TournamentVm model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Tournament.Add(model.Tournament!);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
}