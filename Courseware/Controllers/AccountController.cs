using Courseware.DTOs;
using Courseware.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courseware.Controllers;
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
        => _accountService = accountService;

    public async Task<IActionResult> SignIn(LoginUserDto userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _accountService.SignInAsync(userDto);

        return RedirectToAction("Menu", "Home");
    }

    public async Task<IActionResult> SignUp(RegisterUserDto registerUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _accountService.SignUpAsync(registerUserDto);

        return RedirectToAction("Menu","Home");
    }
}
