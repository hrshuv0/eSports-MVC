using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Admin.Controllers;

public class TournamentCategoriesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public TournamentCategoriesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        var result = _unitOfWork.TournamentCategory.GetAll();

        return View(result);
    }
    
    // Get
    public IActionResult Create()
    {
        return View();
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TournamentCategory model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.TournamentCategory.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var tCategory = _unitOfWork.TournamentCategory.GetFirstOrDefault(c => c.Id == id);

        if (tCategory is null) return NotFound();
        
        return View(tCategory);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(TournamentCategory category)
    {
        if (!ModelState.IsValid)
            return View(category);
        
        _unitOfWork.TournamentCategory.Update(category);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }
    
    // Get
    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var category = _unitOfWork.TournamentCategory.GetFirstOrDefault(c => c.Id == id);

        if (category is null) return NotFound();
        
        return View(category);
    }
    
    // Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var category = _unitOfWork.TournamentCategory.GetFirstOrDefault(c => c.Id == id);

        if (category is null) return NotFound();

        _unitOfWork.TournamentCategory.Remove(category);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    
    
}