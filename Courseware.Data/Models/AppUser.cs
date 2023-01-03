using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courseware.Models;
public class AppUser : IdentityUser
{
    [Required]
    public string? Role { get; set; }
    [Required]
    public int ChatId { get; set; }
}
