using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto response = await Mediator.Send(createUserOperationClaimCommand);
            return Ok(response);
        }
    }
}
