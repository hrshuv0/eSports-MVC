using eSports.entities.Models;

namespace eSports.entities.ViewModels;

public class HomeVm
{
    public IList<Tournament>? Tournaments { get; set; }
    public IList<Game>? Games { get; set; }
}