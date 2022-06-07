using ApiVersioning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers.v2
{
    [ApiController]
   // [Route("api/[controller]")]
   // [Route("api/v{version:apiVersion}/user2")]
     [Route("api/user2")]
    [ApiVersion("2.0")]
    public class User2Controller : ControllerBase
    {

        [HttpGet]
        public IActionResult AllUsers()
        {
            List<UserV2> users = new List<UserV2>() {
                new UserV2() { Id = Guid.NewGuid(), Name ="Mohammad"},
                new UserV2() { Id = Guid.NewGuid(), Name ="Hsaasin"},
                new UserV2() { Id = Guid.NewGuid(), Name ="Ahmed"}
            };
            return Ok(users);
        }
    }
}
