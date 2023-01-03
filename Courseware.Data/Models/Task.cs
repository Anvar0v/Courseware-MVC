using System.ComponentModel.DataAnnotations.Schema;

namespace Courseware.Models;
public class Task
{
    public int? Id { get; set; }
    public string? TaskName { get; set; }
    public string? DeadlineOfTask { get; set; }
    public int? GroupId { get; set; }
    [ForeignKey(nameof(GroupId))]
    public virtual Group? Group { get; set; }
    public virtual List<TaskComment>? Comments { get; set; }

}
