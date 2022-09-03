using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eSports.entities.Models;

public class ApplicationUser : IdentityUser
{
    [StringLength(20)]
    public string? FirstName { get; set; }
    
    [StringLength(20)]
    public string? LastName { get; set; }

    [StringLength(100)]
    public string? Address { get; set; }
    
    [StringLength(20)]
    public string? City { get; set; }
    
    
}