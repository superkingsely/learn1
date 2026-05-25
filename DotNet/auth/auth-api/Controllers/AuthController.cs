using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequestDto request)
    {
        try
        {
             // Implement your registration logic here
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(new { Message = "Registration successful" });
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });  
        }
       
    }
    // [HttpPost("login")]
    // public IActionResult Login([FromBody] LoginRequestDto request)
    // {
    //     // Implement your login logic here
    //     return Ok(new { Message = "Login successful" });
    // }
}