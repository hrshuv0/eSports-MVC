using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class GameRepository : Repository<Game>, IGameRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public GameRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(Game obj)
    {
        _dbContext.Games!.Update(obj);
    }
}