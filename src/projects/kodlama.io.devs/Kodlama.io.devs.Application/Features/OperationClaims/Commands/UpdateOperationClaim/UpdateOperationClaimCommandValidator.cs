using FluentValidation;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public sealed class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Name)
            .MaximumLength(50);
    }
}
