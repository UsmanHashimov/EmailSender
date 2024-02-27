using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.Services.Login
{
    public interface ILoginService
    {
        public Task<string> Login(UserDTO user);
    }
}
