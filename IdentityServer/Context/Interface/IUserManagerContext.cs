using IdentityServer.API.Model.Dto.RequestDto;

namespace IdentityServer.API.Context.Interface
{
    public interface IUserManagerContext
    {
        public Task<bool> CreateUser(UserRequestDto user);
        public Task<bool> IsUserNameExists(string userName);
        public Task<bool> IsEmailExists(string email);
    }
}
