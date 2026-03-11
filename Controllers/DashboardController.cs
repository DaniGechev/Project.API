using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DashboardController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() =>
        Ok(new { message = "Welcome to the protected dashboard!", user = User.Identity?.Name });
}
