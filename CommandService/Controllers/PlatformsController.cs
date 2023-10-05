using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    public PlatformsController()
    {
        
    }

    [HttpPost]
    public IActionResult testInboundConnection()
    {
        Console.WriteLine("Testing POST - inbound # Command service");
        return Ok("Test POST of platforms controller in command service");
    }
}