using Courseware.DTOs;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public interface ITaskService
{
    Task AddTaskAsync(CreateTaskDto dtoModel);
    Task DeleteTaskByIdAsync(int taskId);
    Task<List<Courseware.Models.Task>> GetTasksAsync();
    Task<Courseware.Models.Task> GetTaskByIdAsync(int taskId);
}
