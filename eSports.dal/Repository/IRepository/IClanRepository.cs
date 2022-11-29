using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface IClanRepository : IRepository<Clan>
{
    void Update(Clan obj);
}