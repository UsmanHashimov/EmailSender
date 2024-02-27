using RegisterGmail.Application.IRepositories;
using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepo;
        public RegisterService(IRegisterRepository registerRepo)
            => _registerRepo = registerRepo;
        public async Task<string> Register(UserDTO user)
        {
            var res = await _registerRepo.Register(user);

            return res;
        }

        public async Task<string> VerifyUser(string email, string verificationCode)
        {
            var res = await _registerRepo.VerifyUser(email, verificationCode);

            return res;
        }
    }
}
