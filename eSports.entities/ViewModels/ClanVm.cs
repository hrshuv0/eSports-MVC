using eSports.entities.Models;

namespace eSports.entities.ViewModels;

public class ClanVm
{
    public Clan? Clan { get; set; }
    public List<Clan>? ClanList { get; set; }
}