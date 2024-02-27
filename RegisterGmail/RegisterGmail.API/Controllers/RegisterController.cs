using Microsoft.AspNetCore.Mvc;
using RegisterGmail.Application.Services.Register;
using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public async Task<string> Register([FromForm] UserDTO user)
        {
            var res = await _registerService.Register(user);

            return res;
        }
        [HttpPost]
        public async Task<string> VerifyUser(string email, string verificationCode)
        {
            var res = await _registerService.VerifyUser(email, verificationCode);

            return res;
        }
    }
}
