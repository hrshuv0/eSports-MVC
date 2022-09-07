using System.Security.Claims;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.utility.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Player.Controllers;

[Area("Player")]
public class TeamsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;

    public TeamsController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var result = _unitOfWork.Team.GetAll();

        return View(result);
    }
    
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Team model)
    {
        if (!ModelState.IsValid) return View(model);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var user = _unitOfWork.Player.GetFirstOrDefault(u => u.Id == userId);

        model.TeamMembers = new List<ApplicationUser>(){user!};
        _userManager.AddToRoleAsync(user!, UserRoles.Leader).GetAwaiter().GetResult();

        _unitOfWork.Team.Add(model);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
    
    
    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var team = _unitOfWork.Team.GetFirstOrDefault(c => c.Id == id);

        if (team is null) return NotFound();
        
        return View(team);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Team team)
    {
        if (!ModelState.IsValid)
            return View(team);
        
        _unitOfWork.Team.Update(team);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();
        
        var team = _unitOfWork.Team.GetFirstOrDefault(c => c.Id == id);

        if (team is null) return NotFound();
        
        return View(team);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var team = _unitOfWork.Team.GetFirstOrDefault(c => c.Id == id);

        if (team is null) return NotFound();

        _unitOfWork.Team.Remove(team);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
}