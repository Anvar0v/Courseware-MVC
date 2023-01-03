using Courseware.DTOs;
using Courseware.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace Courseware.Services;
public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task SignInAsync(LoginUserDto dtoModel)
    {
        var isUserExist = await _userManager.FindByEmailAsync(dtoModel.Email);

        if (isUserExist is null)
            throw new Exception("Such user is not found !");
    }

    public async Task SignUpAsync(RegisterUserDto registerUserDto)
    {
        var user = registerUserDto.Adapt<AppUser>();

        if (!await _roleManager.RoleExistsAsync(registerUserDto.Role))
        {
            var role = new IdentityRole(registerUserDto.Role);

            await _roleManager.CreateAsync(role);
        }

        await _userManager.CreateAsync(user, "ada1231@dD");

        await _userManager.AddToRoleAsync(user, user.Role);

        await _signInManager.SignInAsync(user, isPersistent: true);
    }
}
