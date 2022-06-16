using IdentityServer.API.Context.Interface;
using IdentityServer.API.Model.Dto.RequestDto;
using IdentityServer.API.Model.Dto.ResponseDto;
using IdentityServer.Model.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Context.Implementation
{
    public class UserManagerContext : IUserManagerContext
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerContext(UserManager<ApplicationUser> userManager)
        {
            _userManager=userManager;
        }

        public async Task<bool> CreateUser(UserRequestDto user)
        {
            if(user != null)
            {
                var newUser = await _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = false,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = false
                },user.Password);

                if (!newUser.Succeeded)
                {
                    throw new Exception($"Register user errors {String.Join(Environment.NewLine, newUser.Errors.Select(e => e.Description).ToList())}");
                }

                return true;
            }
            throw new NullReferenceException();
        }
    }
}
