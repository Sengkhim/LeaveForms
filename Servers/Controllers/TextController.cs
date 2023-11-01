using Microsoft.AspNetCore.Mvc;

namespace Servers.Controllers;

[ApiController]
[Route("api/")]
public class TextController : ControllerBase
{
    [HttpGet("get-text")]
    public IActionResult GetText()
    {
        return Ok("Hello new world");
    }
}