using ApiVersioning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
  //  [Route("api/users")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult AllUsers()
        {
            List<User> users = new List<User>() { 
                new User() { Id = 1, Name ="Mohammad"},
                new User() { Id = 2, Name ="Hsaasin"},
                new User() { Id = 3, Name ="Ahmed"}
            };
            return Ok(users);
        }
    }
}
