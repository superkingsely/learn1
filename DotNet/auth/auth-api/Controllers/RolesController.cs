

using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext context;

        public RoleController(AppDbContext context) 
    {
        this.context = context;
    }

        [HttpPost("create-role")]
        public IActionResult CreateRole([FromBody] RoleRequestDto role)
        {
            try
            {
                
                var newRole = new Role
                {
                    Id = new Guid(),
                    Name = role.Name,
                    Description = role.Description
                };
                context.Roles.Add(newRole);
                context.SaveChanges();
                return Ok(new { Message = "Role created successfully" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });
            }
        }
       
        [HttpGet("get-roles")]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = context.Roles.ToList();
                var roleResponses = roles.Select(r => new RoleResponseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList();
                return Ok(roleResponses);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = $"Error occurred: {ex.Message}" });
            }
        }
    }
