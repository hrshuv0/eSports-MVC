using eSports.entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eSports.dal.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {


        foreach (var property in builder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }
        
        base.OnModelCreating(builder);
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Game>? Games { get; set; }
    public DbSet<Tournament>? Tournaments { get; set; }
    public DbSet<TournamentCategory>? TournamentCategories { get; set; }
    public DbSet<Prize>? Prizes { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
}