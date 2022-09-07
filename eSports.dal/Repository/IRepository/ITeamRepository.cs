using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface ITeamRepository : IRepository<Team>
{
    void Update(Team obj);
}