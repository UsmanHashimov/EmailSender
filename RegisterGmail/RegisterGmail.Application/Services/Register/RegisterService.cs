using RegisterGmail.Application.IRepositories;
using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.Application.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepo;
        public RegisterService(IRegisterRepository registerRepo)
            => _registerRepo = registerRepo;
        public async Task<string> Register(UserDTO user, string code)
        {
            var res = await _registerRepo.Register(user, code);

            return res;
        }
    }
}
