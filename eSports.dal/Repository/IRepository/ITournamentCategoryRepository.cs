using eSports.entities.Models;

namespace eSports.dal.Repository.IRepository;

public interface ITournamentCategoryRepository : IRepository<TournamentCategory>
{
    void Update(TournamentCategory obj);
}