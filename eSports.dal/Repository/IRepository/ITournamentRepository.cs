using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface ITournamentRepository : IRepository<Tournament>
{
    void Update(Tournament obj);
}