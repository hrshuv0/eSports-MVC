using eSports.entities.Models;
using Microsoft.EntityFrameworkCore;

namespace eSports.dal.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Game>? Games { get; set; }
}