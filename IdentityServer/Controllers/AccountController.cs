using IdentityServer.API.Context.Interface;
using IdentityServer.API.Model.Dto.RequestDto;
using IdentityServer.API.Model.Dto.ResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [ApiController]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserManagerContext _userManagerContext;

        public AccountController(IUserManagerContext userManagerContext)
        {
            _userManagerContext=userManagerContext;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> RegisterUser(UserRequestDto user)
        {
            try
            {
                await _userManagerContext.CreateUser(user);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
