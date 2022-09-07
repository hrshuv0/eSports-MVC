using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class TeamRepository : Repository<Team>, ITeamRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(Team obj)
    {
        _dbContext.Teams!.Update(obj);
    }
}