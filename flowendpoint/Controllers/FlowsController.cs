

using Microsoft.AspNetCore.Mvc;

namespace flowendpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlowsController : ControllerBase
{
    [HttpPost("endpoint")]
    public IActionResult Endpoint()
    {
        Console.WriteLine("okay endpoint hit");
        return Ok("Endpoint called");
    }
}