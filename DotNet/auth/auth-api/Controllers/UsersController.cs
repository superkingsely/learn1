

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                var userDtos = users.Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt,
                    UserType = u.UserType,
                    Roles = u.Roles
                }).ToList();
                return Ok(userDtos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });
            }
        }
       
        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound(new { Message = "User not found" });
                }
                var userDto = new UserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                    UserType = user.UserType,
                    Roles = user.Roles
                };
                return Ok(userDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });
            }
        }

        [HttpPost("addUserRole")]
        public IActionResult AddUserRole(Guid userId, Guid roleId)
{
    try
    {
        var user = _context.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return NotFound(new { Message = "User not found" });
        }

        var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);

        if (role == null)
        {
            return NotFound(new { Message = "Role not found" });
        }

        // avoid duplicates
        if (!user.Roles.Any(r => r.Id == roleId))
        {
            user.Roles.Add(role);
        }

        // optional
        user.UserType = role.Name;

        _context.SaveChanges();

        return Ok(new { Message = "Role added successfully" });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new
        {
            Message = $"Error occurred: {ex.Message}"
        });
    }
}

        /// <summary>Adds a role to a user.</summary>
        /// <param name="id">The user ID.</param>
        /// <param name="role">The role to add.</param>
        /// <returns>The result of the operation.</returns>
       
    //    #region 
       
    //     [HttpPost("addUserRole")]
    //     public IActionResult AddUserRole(Guid id, [FromBody] Role role)
    //     {
    //         try
    //         {
    //             var user = _context.Users.FirstOrDefault(u => u.Id == id);
    //             if (user == null)
    //             {
    //                 return NotFound(new { Message = "User not found" });
    //             }
    //             user.Roles.Add(role);
    //             _context.SaveChanges();
    //             if(user.Roles.Any())
    //             {
    //                 user.UserType = user.Roles.First().Name; // Set UserType based on the first role's name
    //                 _context.SaveChanges();
    //             }
    //             user.UserType=role.Name;
    //             _context.SaveChanges();
    //             return Ok(new { Message = "Role added successfully" });
    //         }
    //         catch (System.Exception ex)
    //         {
    //             return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });
    //         }
    //     }
    //     #endregion
        
        

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound(new { Message = "User not found" });
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok(new { Message = "User deleted successfully" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });
            }
        }
    }
}