

using Microsoft.AspNetCore.Components.Routing;
using webapi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BC= BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
// using webapi.Dtos.Auth;


namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        List<AppUser> users = new(); // temporary in-memory DB
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        // Implement registration and login endpoints here
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new AppUser
            {
                Email = dto.Email,
                PasswordHash = BC.HashPassword(dto.Password)
            };

            users.Add(user);

            return Ok(new { message = "User registered successfully" });
        }

       
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = users.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null || !BC.Verify(dto.Password, user.PasswordHash))
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}