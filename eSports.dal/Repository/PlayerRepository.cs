using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class PlayerRepository : Repository<ApplicationUser>, IPlayerRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(ApplicationUser user)
    {
        throw new NotImplementedException();
    }
}