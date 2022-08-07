﻿using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Game model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Game.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    
}