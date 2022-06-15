using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [ApiController]
    [Route("api/Games")]
    public class AccountController : ControllerBase
    {
        public IActionResult Post(UserModel user)
        {
            return Ok(new UserResponse());
        }

        public class UserModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class UserResponse
        {
            public string Code { get; set; }
        }
    }
}
