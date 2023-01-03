using System.ComponentModel.DataAnnotations;

namespace Courseware.DTOs;
public class CreateGroupDto
{
    [Required]
    public string? GroupName { get; set; }
    [Required]
    public string? Key { get; set; }
}
