using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.IRepositories
{
    public interface IRegisterRepository
    {
        public Task<string> Register(UserDTO user, string code);
    }
}
