using Courseware.Data;
using Courseware.DTOs;
using Courseware.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public class GroupService : IGroupService
{
    private readonly AppDbContext _context;

    public GroupService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddGroupAsync(CreateGroupDto createGroupDto)
    {
        var group = createGroupDto.Adapt<Group>();

        await _context.Groups!.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    public Group GetGroupByName(string? groupName)
        => _context.Groups!.FirstOrDefault(g => g.GroupName == groupName)!;

    public async Task DeleteGroupByIdAsync(int groupId)
    {
        var group = await _context.Groups!.FirstOrDefaultAsync(g => g.Id == groupId);

        if (group is null)
            throw new Exception("Object with given id not found");

        _context.Groups!.Remove(group);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        => await _context.Groups!.ToListAsync();
}
