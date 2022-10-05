using Core.Application.Requests;
using Kodlama.io.devs.Application.Features.OperationClaims.Models;
using Kodlama.io.devs.Application.Features.OperationClaims.Queries.GetByUserIdClaim;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationClaimsController : BaseController
{

    [HttpGet("[action]")]
    public async Task<IActionResult> GetByUserId([FromQuery] PageRequest pageRequest, int userId)
    {
        GetByUserIdClaimsQuery request = new(pageRequest, userId);
        ClaimListModel response = await Mediator.Send(request);
        return Ok(response);
    }
}
