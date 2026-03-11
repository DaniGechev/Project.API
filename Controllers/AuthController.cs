using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.API.Contracts;
using Project.API.Models.HTTP;
using Project.API.Models.User;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly IJwtService _jwt;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(IAuthService auth, IJwtService jwt, UserManager<IdentityUser> userManager)
    {
        _auth = auth;
        _jwt = jwt;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] LoginFormViewModel model)
    {
        var response = new ServiceResponse<string>();

        var success = await _auth.LoginAsync(model);
        if (!success)
        {
            response.Success = false;
            response.Message = "Invalid username or password.";
            return Unauthorized(response);
        }

        var user = await _userManager.FindByNameAsync(model.Username);
        var token = _jwt.GenerateToken(user!);

        Response.Cookies.Append("token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(3)
        });

        response.Success = true;
        response.Message = "Login successful.";
        response.Data = token;
        return Ok(response);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("token");
        return Ok(new ServiceResponse<string> { Success = true, Message = "Logged out." });
    }
}
