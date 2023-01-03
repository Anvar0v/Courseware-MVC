using Courseware.DTOs;
using Courseware.Models;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public interface ITaskCommentService
{
    Task CreateCommentAsync(CreateTaskCommentDto dtoModel);
    Task<List<TaskComment>> GetCommentsAsync();
    Task DeleteComment(int commentId);
}
