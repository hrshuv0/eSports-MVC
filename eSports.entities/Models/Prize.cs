using System.ComponentModel.DataAnnotations;

namespace eSports.entities.Models;

public class Prize
{
    public int Id { get; set; }

    [StringLength(100)]
    [Display(Name = "Prize Name")]
    public string? PrizeName { get; set; } // Follow Name convention with tournament name
    public int PlaceNumber { get; set; } = 1;
    
    [StringLength(20)]
    [Display(Name = "Place Name")]
    public string? PlaceName { get; set; } = "Winner";
    [Display(Name = "Prize Amount")]
    public decimal PrizeAmount { get; set; }
    
    [StringLength(20)]
    [Display(Name = "Place Name")]
    public string? PlaceName2 { get; set; } = "Runners up";
    [Display(Name = "Prize Amount")]
    public decimal PrizeAmount2 { get; set; }
    
    [StringLength(20)]
    [Display(Name = "Place Name")]
    public string? PlaceName3 { get; set; } = "Second runners up";
    [Display(Name = "Prize Amount")]
    public decimal PrizeAmount3 { get; set; }
    
    [Display(Name = "Prize Amount")]
    public decimal PrizeAmount4To10 { get; set; }
    
    
    
    
}