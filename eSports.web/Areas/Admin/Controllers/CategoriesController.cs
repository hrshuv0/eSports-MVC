using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Admin.Controllers;

public class CategoriesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var result = _unitOfWork.Category.GetAll();

        return View(result);
    }
    
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Category.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    
    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);

        if (category is null) return NotFound();
        
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (!ModelState.IsValid)
            return View(category);
        
        _unitOfWork.Category.Update(category);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }
    
    
}