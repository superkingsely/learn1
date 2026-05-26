using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auth_api.Services;
namespace auth_api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
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
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        // Implement your login logic here
        if (!ModelState.IsValid)
        {
            return BadRequest(new {message="invalid field values"});
        }
        if(string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new{message="invalid request email and password are required"});
        }
        var User= _context.Users
        .Include(u=>u.Roles)
        .FirstOrDefault(u=>u.Email==request.Email);
        if (User == null)
        {
            return Unauthorized(new {Message="Invalid email or password"});
        }
        return Ok(new LoginResponseDto
        {
            Token = _jwtService.GenerateJwtToken(User),
            Email = User.Email,
            Username = User.Username,
            CurrentRole = User.UserType,
            Roles = User.Roles.Select(r => r.Name).ToList()
        });
    }
}