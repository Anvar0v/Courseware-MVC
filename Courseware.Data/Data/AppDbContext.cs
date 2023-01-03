using Courseware.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Courseware.Data;
public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DbSet<Models.Task>? Tasks { get; set; }
    public DbSet<Group>? Groups { get; set; }
    public DbSet<TaskComment>? Comments { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}
