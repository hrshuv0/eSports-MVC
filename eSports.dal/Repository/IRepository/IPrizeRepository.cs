using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface IPrizeRepository : IRepository<Prize>
{
    void Update(Prize obj);
    
}