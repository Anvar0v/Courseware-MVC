using Courseware.Data;
using Courseware.DTOs;
using Courseware.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public class TaskCommentService : ITaskCommentService
{
    private readonly AppDbContext _context;

    public TaskCommentService(AppDbContext context)
        => _context = context;

    public async Task CreateCommentAsync(CreateTaskCommentDto dtoModel)
    {
        var comment = dtoModel.Adapt<TaskComment>();

        await _context.Comments!.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteComment(int commentId)
    {
        var comment = _context.Comments!.FirstOrDefault(c => c.Id == commentId);

        if (comment is null)
            throw new Exception("Given comment not found");

        _context.Comments!.Add(comment);
        await _context.SaveChangesAsync();
    }


    public async Task<List<TaskComment>> GetCommentsAsync()
        => await _context.Comments?.ToListAsync() ?? new List<TaskComment>();
}
