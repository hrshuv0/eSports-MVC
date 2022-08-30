using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using eSports.entities.Models;

namespace eSports.dal.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(Category obj)
    {
        _dbContext.Categories!.Update(obj);
    }
}