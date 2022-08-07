using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface IGameRepository : IRepository<Game>
{
    void Update(Game obj);
}