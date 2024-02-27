using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.IRepositories
{
    public interface ILoginRepository
    {
        public Task<string> Login(UserDTO user);
    }
}
