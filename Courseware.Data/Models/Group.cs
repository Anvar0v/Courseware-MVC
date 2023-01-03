using System.ComponentModel.DataAnnotations;

namespace Courseware.Models;
public class Group
{
    public int Id { get; set; }
    [Required]
    public string? GroupName { get; set; }
    [Required]
    public string? Key { get; set; }
    public virtual List<Task>? Tasks { get; set; }
}
