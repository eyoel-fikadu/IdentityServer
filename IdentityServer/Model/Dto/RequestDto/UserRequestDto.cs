namespace IdentityServer.API.Model.Dto.RequestDto
{
    public class UserRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
