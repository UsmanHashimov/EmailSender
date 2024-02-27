using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.IRepositories
{
    public interface IRegisterRepository
    {
        public Task<string> Register(UserDTO user);
        public Task<string> VerifyUser(string email, string verificationCode);
    }
}
