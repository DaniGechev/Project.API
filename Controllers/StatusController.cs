using Microsoft.AspNetCore.Mvc;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("API is running.");
}
