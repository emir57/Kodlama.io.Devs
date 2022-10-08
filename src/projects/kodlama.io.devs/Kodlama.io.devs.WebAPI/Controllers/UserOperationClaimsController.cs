using Core.Application.Requests;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Queries.ListUserClaims;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserOperationClaimsController : BaseController
    {

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId([FromQuery] PageRequest pageRequest, [FromRoute] int userId)
        {
            GetListUserClaimsQuery getListUserClaimsQuery = new(userId, pageRequest);
            UserClaimListModel userClaimListModel = await Mediator.Send(getListUserClaimsQuery);
            return Ok(userClaimListModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto response = await Mediator.Send(createUserOperationClaimCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto response = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(response);
        }

        [HttpDelete("users/{userId}/claims/{operationClaimId}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto response = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(response);
        }
    }
}
