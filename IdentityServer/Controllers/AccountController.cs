using IdentityServer.API.Context.Interface;
using IdentityServer.API.Model.Dto.RequestDto;
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

        [HttpGet]
        [Route("isUserNameExists")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<bool> IsUserNameExists(string userName)
        {
            return await _userManagerContext.IsUserNameExists(userName);
        }

        [HttpGet]
        [Route("isEmailExists")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<bool> IsEmailExists(string email)
        {
            return await _userManagerContext.IsEmailExists(email);
        }
    }
}
