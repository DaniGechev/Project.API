using Microsoft.AspNetCore.Identity;
using Project.API.Contracts;
using Project.API.Models.User;

namespace Project.API.Services;

public class AuthService : IAuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> LoginAsync(LoginFormViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null) return false;

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
        return result.Succeeded;
    }
}
