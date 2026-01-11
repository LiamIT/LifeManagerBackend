using System.ComponentModel.DataAnnotations;
namespace LifeManagerBackend.Models;
public class User
{
    public int fintid { get; set; }
    
    [Required]
    public string fstrusername { get; set; } = string.Empty;
    
    [Required]
    public string fstremail { get; set; } = string.Empty;

    // Hashed password (never store plain text!)
    //public string PasswordHash { get; set; } = string.Empty;

    public DateTime fdtmcreated { get; set; } = DateTime.UtcNow;
}