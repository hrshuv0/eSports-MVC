using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class PrizeRepository : Repository<Prize>, IPrizeRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public PrizeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(Prize obj)
    {
        _dbContext.Prizes!.Update(obj);
    }
}