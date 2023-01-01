using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.web.Areas.Admin.Controllers;

[Area("Admin")]
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
    
    public IActionResult Details(int? id)
    {
        var result = _unitOfWork.Tournament.GetFirstOrDefault(t => t.Id == id, includeProperties:"Game,TournamentCategory,Prize");

        return View(result);
    }
    
    public IActionResult Create()
    {
        TournamentVm tournamentVm = new TournamentVm()
        {
            Tournament = new Tournament(),
            PrizeList = _unitOfWork.Prize.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.PrizeName,
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

        var prize = _unitOfWork.Prize.GetFirstOrDefault(p => p.Id == model.Tournament!.PrizeId);

        model.Tournament!.PrizePool =
            prize!.PrizeAmount + prize.PrizeAmount2 + prize.PrizeAmount3 + prize.PrizeAmount4To10 * 6;
        
        _unitOfWork.Tournament.Add(model.Tournament!);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    // Get
    public IActionResult Edit(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var tournament = _unitOfWork.Tournament.GetFirstOrDefault(u => u.Id == id);

        TournamentVm tournamentVm = new TournamentVm()
        {
            Tournament = tournament,
            PrizeList = _unitOfWork.Prize.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.PrizeName,
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

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(TournamentVm model)
    {
        if (!ModelState.IsValid) return View(model);

        var prize = _unitOfWork.Prize.GetFirstOrDefault(p => p.Id == model.Tournament!.PrizeId);

        model.Tournament!.PrizePool =
            prize!.PrizeAmount + prize.PrizeAmount2 + prize.PrizeAmount3 + prize.PrizeAmount4To10 * 6;
        
        _unitOfWork.Tournament.Update(model.Tournament!);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var result = _unitOfWork.Tournament.GetFirstOrDefault(t => t.Id == id, includeProperties:"Game,TournamentCategory,Prize");

        return View(result);
    }
    
    // Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var tournament = _unitOfWork.Tournament.GetFirstOrDefault(c => c.Id == id);

        if (tournament is null) return NotFound();

        _unitOfWork.Tournament.Remove(tournament);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    

    
}