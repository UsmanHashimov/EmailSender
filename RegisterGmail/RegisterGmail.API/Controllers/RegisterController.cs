using Microsoft.AspNetCore.Mvc;
using RegisterGmail.Application.Services.Register;
using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public async Task<string> Register([FromForm] UserDTO user, string code)
        {
            var res = await _registerService.Register(user, code);

            return res;
        }
    }
}
