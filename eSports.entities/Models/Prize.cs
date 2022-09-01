namespace eSports.entities.Models;

public class Prize
{
    public int Id { get; set; }
    public int PlaceNumber { get; set; }
    public string? PlaceName { get; set; }
    public decimal PrizeAmount { get; set; }
    public int? PrizePercentage { get; set; }

    public IEnumerable<TournamentPrize>? TournamentPrizes { get; set; }
}