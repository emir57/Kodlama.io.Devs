using FluentValidation;

namespace Kodlama.io.devs.Application.Features.GitHubs.Commands.UpdateGitHub;

public sealed class UpdateGitHubCommandValidator : AbstractValidator<UpdateGitHubCommand>
{
    public UpdateGitHubCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.Id)
            .GreaterThan(0);

        RuleFor(c => c.ProfileUserName)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.ProfileUserName)
            .MinimumLength(1);

        RuleFor(c => c.ProfileUserName)
            .MaximumLength(50);
    }
}
