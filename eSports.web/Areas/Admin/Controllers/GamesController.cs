﻿using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSports.web.Areas.Admin.Controllers;

public class GamesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public GamesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    public IActionResult Index()
    {
        var result = _unitOfWork.Game.GetAll();
        
        return View(result);
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
    public IActionResult Create(GameVm model)
    {
        if (!ModelState.IsValid) return View(model);
        
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
    public IActionResult Edit(GameVm model)
    {
        if (!ModelState.IsValid) return View(model);
        
        _unitOfWork.Game.Update(model.Game);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    
}