

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello from the API!" });
        }
    }
}