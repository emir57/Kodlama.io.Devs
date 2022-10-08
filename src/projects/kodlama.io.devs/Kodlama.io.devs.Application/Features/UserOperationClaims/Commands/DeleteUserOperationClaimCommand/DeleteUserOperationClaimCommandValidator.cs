using FluentValidation;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand;

public sealed class DeleteUserOperationClaimCommandValidator : AbstractValidator<DeleteUserOperationClaimCommand>
{
    public DeleteUserOperationClaimCommandValidator()
    {
        RuleFor(d => d.UserId)
            .NotEmpty()
            .NotNull();
        RuleFor(d => d.OperationClaimId)
            .NotEmpty()
            .NotNull();
    }
}
