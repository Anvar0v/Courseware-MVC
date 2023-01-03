namespace Courseware.DTOs;
public class CreateTaskDto
{
    public string? TaskName { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public string? GroupName { get; set; }
    public string? DeadlineOfTask { get; set; }
    public int? GroupId { get; set; }
}