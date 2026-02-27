using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        [HttpGet("test")]
        public async Task<ActionResult> Testy()
        {
            return Ok("cool greta");
        }
    }
}
