using System.Threading.Tasks;
using Actio.Common.Auth;
using Actio.Common.Commands;
using Actio.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actio.Services.Identity.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<JsonWebToken> Login([FromBody] AuthenticateUser command)
            => await _userService.Login(command.Email, command.Password);
    }
}