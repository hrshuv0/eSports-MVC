using eSports.entities.Models;

namespace eSports.entities.ViewModels;

public class HomeVm
{
    public IEnumerable<Tournament>? Tournaments { get; set; }
    public IEnumerable<Game>? Games { get; set; }
}