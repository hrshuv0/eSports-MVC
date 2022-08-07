namespace eSports.dal.Repository.IRepository;

public interface IUnitOfWork
{
    IGameRepository Game { get; }
    ITournamentRepository Tournament { get; }


    void Save();
}