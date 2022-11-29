using System.Security.Claims;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;
using eSports.entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Player.Controllers;

[Area("Player")]
[Authorize]
public class ClansController : Controller
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;



    public ClansController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        _UnitOfWork = unitOfWork;
        _userManager = userManager;
    }

    // GET
    public IActionResult Index()
    {
        var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = _userManager.FindByIdAsync(uId).Result;
        var clan = user.Clan ?? new Clan();
        var clanList = _UnitOfWork.Clan.GetAll() ?? new List<Clan>();
        
        
        ClanVm clanVm = new ClanVm()
        {
            Clan = clan,
            ClanList = clanList
        };

        return View();
    }
}