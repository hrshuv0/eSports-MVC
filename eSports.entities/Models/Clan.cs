namespace eSports.entities.Models;

public class Clan
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string? ImageUrl { get; set; }

    public List<ApplicationUser>? PlayerList { get; set; }
    
    
}