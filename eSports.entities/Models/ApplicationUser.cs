using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eSports.entities.Models;

public class ApplicationUser : IdentityUser
{
    [StringLength(20)]
    public string? GameId { get; set; }
    
    [StringLength(20)]
    public string? FirstName { get; set; }
    
    [StringLength(20)]
    public string? LastName { get; set; }

    [StringLength(100)]
    public string? Address { get; set; }
    
    [StringLength(20)]
    public string? City { get; set; }

    public int? TeamId { get; set; }
    [ForeignKey("TeamId")]
    [ValidateNever]
    public Team? Team { get; set; }

    public int? ClanId { get; set; }
    [ForeignKey("ClanId")]
    [ValidateNever]
    public Clan? Clan { get; set; }
    
    
}