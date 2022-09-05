using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface IPlayerRepository : IRepository<ApplicationUser>
{
    void Update(ApplicationUser user);

}