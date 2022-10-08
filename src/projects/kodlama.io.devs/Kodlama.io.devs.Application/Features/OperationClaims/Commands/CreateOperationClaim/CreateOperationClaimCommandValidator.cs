using FluentValidation;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public sealed class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.Name)
            .MaximumLength(50);
    }
}
