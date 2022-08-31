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

    public T? GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties=null)
    {
        var query = _dbSet.Where(filter);
        
        if (includeProperties is not null)
        {
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property).DefaultIfEmpty();
        }
        
        return query.FirstOrDefault();
    }

    public IEnumerable<T>? GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties=null)
    {
        IQueryable<T> query = _dbSet;

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includeProperties is not null)
        {
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property).DefaultIfEmpty();
        }
        
        return query.ToList();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        _dbSet.RemoveRange(entity);
    }
}