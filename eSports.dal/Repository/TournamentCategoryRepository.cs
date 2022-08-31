using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class TournamentCategoryRepository : Repository<TournamentCategory>, ITournamentCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public TournamentCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(TournamentCategory obj)
    {
        _dbContext.TournamentCategories!.Update(obj);
    }
}