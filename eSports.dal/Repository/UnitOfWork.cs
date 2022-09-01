using eSports.dal.Data;
using eSports.dal.Repository.IRepository;

namespace eSports.dal.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public ICategoryRepository Category { get; }
    public IGameRepository Game { get; }
    public ITournamentRepository Tournament { get; }
    public ITournamentCategoryRepository TournamentCategory { get; }
    public IPrizeRepository Prize { get; }

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        
        Category = new CategoryRepository(_dbContext);
        Game = new GameRepository(_dbContext);
        Tournament = new TournamentRepository(_dbContext);
        TournamentCategory = new TournamentCategoryRepository(_dbContext);
        Prize = new PrizeRepository(_dbContext);
    }


    
    
    
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}