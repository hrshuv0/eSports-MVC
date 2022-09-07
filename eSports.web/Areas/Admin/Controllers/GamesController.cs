using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.web.Areas.Admin.Controllers;

[Area("Admin")]
public class GamesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public GamesController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
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
        
        var game = _unitOfWork.Game.GetFirstOrDefault(c => c.Id == id, includeProperties:"Category");

        return View(game);
    }
    
    // Get
    public IActionResult Create()
    {
        var gameVm = new GameVm()
        {
            Game = new Game(),
            CategoryList = _unitOfWork.Category.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
        };
        
        return View(gameVm);
    }
    
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(GameVm model, IFormFile? file)
    {
        if (!ModelState.IsValid) return View(model);
        
        model.CategoryList = _unitOfWork.Category.GetAll()!.Select(c => new SelectListItem()
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });

        string wwwRootPath = _hostEnvironment.WebRootPath;
        if (file is not null)
        {
            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(wwwRootPath, @"images\games");
            var extension = Path.GetExtension(file.FileName);

            using var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create);
            file.CopyTo(fileStream);

            model.Game.ImageUrl = @"\images\games\" + fileName + extension;
        }
        
        _unitOfWork.Game.Add(model.Game);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    // Get
    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();

        var game = _unitOfWork.Game.GetFirstOrDefault(g => g.Id == id)!;
        var gameVm = new GameVm()
        {
            Game = game,
            CategoryList = _unitOfWork.Category.GetAll()!.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
        };

        return View(gameVm);
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(GameVm model, IFormFile? file)
    {
        model.CategoryList = _unitOfWork.Category.GetAll()!.Select(c => new SelectListItem()
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });
        
        if (!ModelState.IsValid) return View(model);
        
        string wwwRootPath = _hostEnvironment.WebRootPath;
        if (file is not null)
        {
            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(wwwRootPath, @"images\games");
            var extension = Path.GetExtension(file.FileName);

            if (model.Game.ImageUrl is not null)
            {
                var oldImagePath = Path.Combine(wwwRootPath, model.Game.ImageUrl.TrimStart('\\'));
                if(System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);
            }
            
            using var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create);
            file.CopyTo(fileStream);

            model.Game.ImageUrl = @"\images\games\" + fileName + extension;
        }

        _unitOfWork.Game.Update(model.Game);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    // Get
    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var game = _unitOfWork.Game.GetFirstOrDefault(c => c.Id == id, includeProperties:"Category");

        if (game is null) return NotFound();
        
        return View(game);
    }
    
    // Post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var game = _unitOfWork.Game.GetFirstOrDefault(c => c.Id == id);

        if (game is null) return NotFound();
        
        string wwwRootPath = _hostEnvironment.WebRootPath;
        if (game.ImageUrl is not null)
        {
            var oldImagePath = Path.Combine(wwwRootPath, game.ImageUrl.TrimStart('\\'));
            if(System.IO.File.Exists(oldImagePath))
                System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.Game.Remove(game);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }

    
}