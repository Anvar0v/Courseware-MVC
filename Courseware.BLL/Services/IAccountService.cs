using Courseware.DTOs;

namespace Courseware.Services;
public interface IAccountService
{
    Task SignInAsync(LoginUserDto dtoModel);
    Task SignUpAsync(RegisterUserDto dtoModel);
}
