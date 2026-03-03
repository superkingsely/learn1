using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.Models.InputModel;
using SERVICE.Iservice;

namespace API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthuticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthuticationController(IAuthService authService)
        {
            _authService=authService;
        }
       [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUserLoginInputModel model)
        {
            var response = await _authService.LoginAsync(model);
            return response.IsSuccess ? Ok() : BadRequest(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserRegisterInputModel model)
        {
            var response= await _authService.RegisterAsync(model);
            return Ok(response);
        }
    }
}
