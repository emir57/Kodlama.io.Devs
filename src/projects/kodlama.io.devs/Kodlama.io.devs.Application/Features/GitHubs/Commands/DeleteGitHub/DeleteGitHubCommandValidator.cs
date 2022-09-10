using FluentValidation;

namespace Kodlama.io.devs.Application.Features.GitHubs.Commands.DeleteGitHub;

public sealed class DeleteGitHubCommandValidator : AbstractValidator<DeleteGitHubCommand>
{
    public DeleteGitHubCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull();
        RuleFor(d => d.Id)
            .GreaterThan(0);
    }
}
