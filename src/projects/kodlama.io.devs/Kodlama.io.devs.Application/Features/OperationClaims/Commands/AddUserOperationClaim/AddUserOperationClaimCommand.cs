using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.AddUserOperationClaim;

public sealed class AddUserOperationClaimCommand : IRequest<AddedUserOperationClaimDto>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}
