using FluentValidation;

namespace Kodlama.io.devs.Application.Features.GitHubs.Commands.CreateGitHub;

public sealed class CreateGitHubCommandValidator : AbstractValidator<CreateGitHubCommand>
{
    public CreateGitHubCommandValidator()
    {
        RuleFor(c => c.ProfileUserName)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.ProfileUserName)
            .MinimumLength(1);

        RuleFor(c => c.ProfileUserName)
            .MaximumLength(50);
    }
}
