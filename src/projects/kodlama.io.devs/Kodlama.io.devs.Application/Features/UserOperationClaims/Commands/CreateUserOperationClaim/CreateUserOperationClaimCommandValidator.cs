using FluentValidation;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public sealed class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.OperationClaimId)
            .NotEmpty()
            .NotNull();
    }
}
