using eSports.dal.Data;
using eSports.entities.Models;
using eSports.utility.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eSports.dal.SeedData;

public class DbInitializer : IDbInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _dbContext;

    public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
    }

    public void Initialize()
    {
        try
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                _dbContext.Database.Migrate();
            }
        }
        catch (Exception ex)
        {
            // ignored
        }

        if (!_roleManager.RoleExistsAsync(UserRoles.Admin).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(UserRoles.Player)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(UserRoles.Leader)).GetAwaiter().GetResult();

            // Create Admin
            var userAdmin = new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@email.com",
                FirstName = "Super",
                LastName = "Admin",
                PhoneNumber = "+966567",
                Address = "5/A, NY",
                City = "New York",
                EmailConfirmed = true
            };
            _userManager.CreateAsync(userAdmin, password: "1234").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userAdmin, UserRoles.Admin).GetAwaiter().GetResult();

            // Create player
            var userPlayer = new ApplicationUser()
            {
                UserName = "player",
                Email = "player@email.com",
                FirstName = "Mr",
                LastName = "Player",
                PhoneNumber = "+895576",
                Address = "27/C, WD",
                City = "Washington DC",
                EmailConfirmed = true
            };
            _userManager.CreateAsync(userPlayer, password: "1234").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userPlayer, UserRoles.Player).GetAwaiter().GetResult();
        }
    }

}