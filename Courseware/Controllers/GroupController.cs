using Courseware.DTOs;
using Courseware.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courseware.Controllers;
public partial class GroupController : Controller
{
    private readonly IGroupService _groupService;
    private readonly ITaskService _taskService;
    private readonly ITaskCommentService _commentService;

    public GroupController(IGroupService groupService,
        ITaskService taskService,
        ITaskCommentService commentService)
    {
        _groupService = groupService;
        _taskService = taskService;
        _commentService = commentService;
    }

    [Authorize(Policy = "AddingRights")]
    public IActionResult AddNewGroup(CreateGroupDto groupDto)
    {
        if (!ModelState.IsValid)
            return View();

        _groupService.AddGroupAsync(groupDto);

        return RedirectToAction("InGroup", new { groupName = groupDto.GroupName });
    }

    public IActionResult JoinToGroup(string groupName, string key)
    {
        var group = _groupService.GetGroupByName(groupName);

        if (group is not null && key == group.Key)
            return RedirectToAction("InGroup", new { groupName = group.GroupName });

        return View();
    }

    public IActionResult InGroup(string groupName)
    {
        var group = _groupService.GetGroupByName(groupName);

        return View(group);
    }

    public async Task<IActionResult> DeleteGroup(int groupId)
    {
        await _groupService.DeleteGroupByIdAsync(groupId);
        return Ok();
    }
}
