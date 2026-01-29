using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using playground.DTOs;
using playground.Repository;

namespace playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepo UserRepo { get; }
        public UsersController(IUserRepo userRepo)
        {
            UserRepo = userRepo;
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUser user)
        {
            var createdUser = new Entity.User
            {
                Name = user.Name,
                Email = user.Email,
                Class = user.Class
            };
            UserRepo.CreateUser(createdUser);
            return Ok(createdUser);
        }
    }
}
