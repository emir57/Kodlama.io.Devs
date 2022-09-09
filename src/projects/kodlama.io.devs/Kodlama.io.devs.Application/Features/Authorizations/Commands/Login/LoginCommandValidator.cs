using FluentValidation;

namespace Kodlama.io.devs.Application.Features.Authorizations.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(l => l.UserForLoginDto.Email)
            .NotEmpty()
            .NotNull();
        RuleFor(l => l.UserForLoginDto.Email)
            .EmailAddress();
        RuleFor(l => l.UserForLoginDto.Email)
            .MaximumLength(50);

        RuleFor(l => l.UserForLoginDto.Password)
            .NotEmpty()
            .NotNull();
        RuleFor(l => l.UserForLoginDto.Password)
            .MinimumLength(6);
        RuleFor(l => l.UserForLoginDto.Password)
            .MaximumLength(25);
    }
}
