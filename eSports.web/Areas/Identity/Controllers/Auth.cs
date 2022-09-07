using eSports.entities.Models;
using eSports.utility.StaticData;
using eSports.web.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eSports.web.Areas.Identity.Controllers;

[Area("Identity")]
public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET
    public IActionResult Register()
    {
        return View();
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user is not null)
        {
            ModelState.AddModelError(string.Empty, "user already exists");
            return View(model);
        }

        var newUser = new ApplicationUser()
        {
            UserName = model.UserName,
            Email = model.Email,
            GameId = model.GameId
        };
        var response = await _userManager.CreateAsync(newUser, model.Password);

        if (!response.Succeeded)
        {
            return View(model);
        }

        await _userManager.AddToRoleAsync(newUser, UserRoles.Player);

        var result = await _signInManager.PasswordSignInAsync(newUser, model.Password, false, false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home", new { area = "Player" });
        }

        return View(model);
    }
    
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVm model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user is not null)
        {
            var checkCredentials = await _userManager.CheckPasswordAsync(user, model.Password);
            if (checkCredentials)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index), "Home", new {area="Player"});
            }
        }
        ModelState.AddModelError(string.Empty, "wrong credentials");

        return View(model);
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Index), "Home", new {area="Player"});
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
    
    
}