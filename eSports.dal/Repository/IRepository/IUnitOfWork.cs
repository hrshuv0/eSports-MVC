namespace eSports.dal.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IGameRepository Game { get; }
    ITournamentRepository Tournament { get; }


    void Save();
}