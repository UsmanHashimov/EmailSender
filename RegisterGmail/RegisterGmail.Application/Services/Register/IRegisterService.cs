using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.Services.Register
{
    public interface IRegisterService
    {
        public Task<string> Register(UserDTO user);
        public Task<string> VerifyUser(string email, string verificationCode);
    }
}
