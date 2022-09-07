using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.web.Areas.Admin.Controllers;

[Area("Admin")]
public class PrizesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PrizesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        var result = _unitOfWork.Prize.GetAll();
        
        return View(result);
    }
    
    public IActionResult Details(int? id)
    {
        var prize = _unitOfWork.Prize.GetFirstOrDefault(g => g.Id == id)!;
        
        return View(prize);
    }
    
    // Get
    public IActionResult Create()
    {
        Prize prize = new Prize();
        
        return View(prize);
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Prize model)
    {
        if (!ModelState.IsValid) return View(model);
        
        _unitOfWork.Prize.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    // Get
    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();

        var prize = _unitOfWork.Prize.GetFirstOrDefault(g => g.Id == id)!;
        
        return View(prize);
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Prize model)
    {
        
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Prize.Update(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    // Get
    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var prize = _unitOfWork.Prize.GetFirstOrDefault(c => c.Id == id);

        if (prize is null) return NotFound();
        
        return View(prize);
    }
    
    // Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var prize = _unitOfWork.Prize.GetFirstOrDefault(c => c.Id == id);

        if (prize is null) return NotFound();

        _unitOfWork.Prize.Remove(prize);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }


    
}