using IdentityServer.API.Model.Dto.RequestDto;

namespace IdentityServer.API.Context.Interface
{
    public interface IUserManagerContext
    {
        public Task<bool> CreateUser(UserRequestDto user);
    }
}
