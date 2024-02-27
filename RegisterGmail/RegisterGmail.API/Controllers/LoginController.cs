using Microsoft.AspNetCore.Mvc;
using RegisterGmail.Application.Services.Login;
using RegisterGmail.Domain.Entities.DTOs;

namespace RegisterGmail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
           => _loginService = loginService;

        [HttpPost]
        public async Task<string> Login([FromForm] UserDTO user)
        {
            var res = await _loginService.Login(user);

            return res;
        }

    }
}
