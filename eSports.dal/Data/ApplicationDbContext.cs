using eSports.entities.Models;
using Microsoft.EntityFrameworkCore;

namespace eSports.dal.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Game>? Games { get; set; }
    public DbSet<Tournament>? Tournaments { get; set; }
    public DbSet<TournamentCategory>? TournamentCategories { get; set; }
    public DbSet<Prize>? Prizes { get; set; }
}