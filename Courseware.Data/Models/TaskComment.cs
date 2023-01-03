using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courseware.Models;
public class TaskComment
{
    public int Id { get; set; }
    [Required]
    public string? Comment { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.Now;

    public int? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public virtual TaskComment? Parent { get; set; }
    public virtual List<TaskComment>? Children { get; set; }

    public int? TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public virtual Task? Task { get; set; }
}
//https://codepen.io/faisalbrur/pen/ExKwGJr