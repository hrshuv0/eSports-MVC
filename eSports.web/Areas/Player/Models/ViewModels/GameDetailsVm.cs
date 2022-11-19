using eSports.entities.Models;

namespace eSports.web.Areas.Player.Models.ViewModels;

public class GameDetailsVm
{
    public Game? Game { get; set; }
    public IList<Tournament>? TournamentList { get; set; }
}