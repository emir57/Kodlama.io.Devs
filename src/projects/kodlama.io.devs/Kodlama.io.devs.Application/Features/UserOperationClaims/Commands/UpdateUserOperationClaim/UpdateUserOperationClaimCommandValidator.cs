using FluentValidation;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public sealed class UpdateUserOperationClaimCommandValidator : AbstractValidator<UpdateUserOperationClaimCommand>
{
    public UpdateUserOperationClaimCommandValidator()
    {
        RuleFor(u => u.UserId)
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.OperationClaimId)
            .NotEmpty()
            .NotNull();
    }
}
