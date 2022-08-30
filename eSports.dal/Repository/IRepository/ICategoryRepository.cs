using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
}