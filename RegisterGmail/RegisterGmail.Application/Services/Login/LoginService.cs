using RegisterGmail.Application.IRepositories;
using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepo;
        public LoginService(ILoginRepository loginRepository)
           => _loginRepo = loginRepository;

        public async Task<string> Login(UserDTO user)
        {
            var res = await _loginRepo.Login(user);

            return res;
        }
    }
}
