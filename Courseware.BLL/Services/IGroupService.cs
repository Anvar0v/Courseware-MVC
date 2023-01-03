using Courseware.DTOs;
using Courseware.Models;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public interface IGroupService
{
    Task AddGroupAsync(CreateGroupDto dtoModel);
    Group GetGroupByName(string groupName);
    Task DeleteGroupByIdAsync(int groupId);
    Task<IEnumerable<Group>> GetAllGroupsAsync();
}
