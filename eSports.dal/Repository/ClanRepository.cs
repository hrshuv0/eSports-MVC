using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class ClanRepository : Repository<Clan>, IClanRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ClanRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(Clan obj)
    {
        _dbContext.Clans!.Update(obj);
    }
}