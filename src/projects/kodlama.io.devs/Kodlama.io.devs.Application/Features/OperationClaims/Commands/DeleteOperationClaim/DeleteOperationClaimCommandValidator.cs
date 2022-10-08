using FluentValidation;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public sealed class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull();
    }
}
