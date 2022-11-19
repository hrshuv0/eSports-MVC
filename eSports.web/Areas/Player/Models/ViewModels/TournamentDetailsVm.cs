using eSports.entities.Models;

namespace eSports.web.Areas.Player.Models.ViewModels;

public class TournamentDetailsVm
{
    public Tournament? Tournament { get; set; }
    public IList<Tournament>? TournamentList { get; set; }

    public TournamentDetailsVm()
    {
        Tournament = new Tournament();
        TournamentList = new List<Tournament>();
    }
}