using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc;

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
        var result = _unitOfWork.Tournament.GetAll();
        
        return View(result);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Tournament model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Tournament.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
}