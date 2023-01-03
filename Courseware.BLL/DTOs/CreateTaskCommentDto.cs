using System.ComponentModel.DataAnnotations;

namespace Courseware.DTOs;
public class CreateTaskCommentDto
{
    [Required]
    public string? Comment { get; set; }
}

