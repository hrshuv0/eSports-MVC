using System.Linq.Expressions;
using eSports.dal.Data;
using eSports.dal.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace eSports.dal.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public T? GetFirstOrDefault(Expression<Func<T, bool>> filter)
    {
        var query = _dbSet.Where(filter);
        
        return query.FirstOrDefault();
    }

    public IEnumerable<T>? GetAll(Expression<Func<T, bool>>? filter)
    {
        IQueryable<T> query = _dbSet;

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        return query.ToList();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }
}