using Project.API.Models.User;

namespace Project.API.Contracts;

public interface IAuthService
{
    Task<bool> LoginAsync(LoginFormViewModel model);
}
