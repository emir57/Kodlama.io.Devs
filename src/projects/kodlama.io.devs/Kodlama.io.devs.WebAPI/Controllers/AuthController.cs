using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.devs.Application.Features.Authorizations.Commands.Login;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand request = new() { UserForLoginDto = userForLoginDto };
            AccessToken result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
