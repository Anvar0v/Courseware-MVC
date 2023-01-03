using Courseware.Data;
using Courseware.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddTaskAsync(CreateTaskDto dtoModel)
    {
        var task = dtoModel.Adapt<Courseware.Models.Task>();

        await _context.Tasks!.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskByIdAsync(int taskId)
    {
        var task = await _context.Tasks!.FirstOrDefaultAsync(t => t.Id == taskId);

        if (task is null)
            throw new Exception("Task with given Id is not found !");

        _context.Tasks!.Remove(task);
        await _context.SaveChangesAsync();
    }

    public async Task<Models.Task> GetTaskByIdAsync(int taskId)
    {
        var task = await _context.Tasks!.FirstOrDefaultAsync(t => t.Id == taskId);

        if (task is null)
            throw new Exception("Task with given Id is not found !");

        return task;
    }

    public async Task<List<Models.Task>> GetTasksAsync()
        => await _context.Tasks!.ToListAsync();

}
