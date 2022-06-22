using IdentityServer.API.Context.Interface;
using IdentityServer.API.Model;
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
        [ProducesResponseType(422)]
        public async Task<IActionResult> RegisterUser(UserRequestDto user)
        {
            try
            {
                var value = await _userManagerContext.CreateUser(user);
                return Ok(ResponseModel.GetSuccess(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseModel.GetError(ex));
            }
            
        }

        [HttpGet]
        [Route("isUserNameExists")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> IsUserNameExists(string userName)
        {
            var result = await _userManagerContext.IsUserNameExists(userName);
            return Ok(ResponseModel.GetSuccess(result));
        }

        [HttpGet]
        [Route("isEmailExists")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> IsEmailExists(string email)
        {
            var result = await _userManagerContext.IsEmailExists(email);
            return Ok(ResponseModel.GetSuccess(result));
        }
    }
}
