using Courseware.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Courseware.Controllers;

public partial class GroupController : Controller
{
    public async Task<IActionResult> AddComment(CreateTaskCommentDto dtoModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _commentService.CreateCommentAsync(dtoModel);
        return Ok();
    }
    //get action
    public async Task GetComments()
       => await _commentService.GetCommentsAsync();

    public void DeleteComment(int commentId)
       => _commentService.DeleteComment(commentId);
}
