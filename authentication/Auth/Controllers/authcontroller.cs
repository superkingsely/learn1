using Auth.Models.DTOs;
using Auth.Services.contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authcontroller : ControllerBase
    {
        private readonly IAuthService authService;

        public Authcontroller(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponseDto<object>>> RegAsync([FromBody] RegisterDto model)
        {
            var res= await authService.RegisterAsync(model);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponseDto<object>>> LoginAsync([FromBody] LoginDto model)
        {
            var res= await authService.LoginAsync(model);
            if (!res.Success)
            {
                return Unauthorized(res);
            }
            return Ok(res);
        }
    }
}
