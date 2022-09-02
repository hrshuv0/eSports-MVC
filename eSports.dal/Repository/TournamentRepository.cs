using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class TournamentRepository : Repository<Tournament>, ITournamentRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public TournamentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(Tournament obj)
    {
        _dbContext.Tournaments!.Update(obj);
    }
}