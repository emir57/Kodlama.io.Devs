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

        RuleFor(u => u.ProfileUserName)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.ProfileUserName)
            .MinimumLength(1);

        RuleFor(u => u.ProfileUserName)
            .MaximumLength(50);
    }
}
