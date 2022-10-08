using Core.Application.Requests;
using Kodlama.io.devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.OperationClaims.Models;
using Kodlama.io.devs.Application.Features.OperationClaims.Queries.GetListClaims;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationClaimsController : BaseController
{

    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
    {
        GetListClaimsQuery request = new(pageRequest);
        ClaimListModel response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaim response = await Mediator.Send(createOperationClaimCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaim response = await Mediator.Send(updateOperationClaimCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        DeletedOperationClaim response = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(response);
    }
}
