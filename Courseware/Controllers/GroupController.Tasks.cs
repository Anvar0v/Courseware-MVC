using Courseware.DTOs;
using Courseware.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courseware.Controllers;
public partial class GroupController : Controller
{
    public async Task<IActionResult> TaskDetails(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task is null)
            return NotFound();

        return View(task);
    }

    [Authorize(Policy = "AddingRights")]
    public async Task<IActionResult> AddNewTask(CreateTaskDto taskDto)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var group = _groupService.GetGroupByName(taskDto.GroupName!);

        if (group is null)
            return NotFound("404 Error entered group was not found");

        var deadline = new DateTime
            (taskDto.Year, taskDto.Month, taskDto.Day).ToString("d");

        taskDto.GroupId = group.Id;
        taskDto.DeadlineOfTask = deadline;

        await _taskService.AddTaskAsync(taskDto);

        return RedirectToAction("InGroup", new { groupName = taskDto.GroupName });
    }

    public async Task<IActionResult> DeleteTaskById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        await _taskService.DeleteTaskByIdAsync(id);

        return RedirectToAction("InGroup", new { groupName = task.Group?.GroupName });
    }

    public IActionResult AddTaskComment(CreateTaskCommentDto commentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        commentDto.Adapt<TaskComment>();

        return Ok();
    }


}
