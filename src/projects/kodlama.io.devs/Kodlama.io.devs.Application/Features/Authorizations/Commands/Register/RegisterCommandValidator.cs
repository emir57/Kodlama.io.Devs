using Core.Security.Dtos;
using FluentValidation;

namespace Kodlama.io.devs.Application.Features.Authorizations.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.UserForRegisterDto.FirstName)
            .NotEmpty()
            .NotNull();
        RuleFor(r => r.UserForRegisterDto.FirstName)
            .MaximumLength(50);

        RuleFor(r => r.UserForRegisterDto.LastName)
            .NotEmpty()
            .NotNull();
        RuleFor(r => r.UserForRegisterDto.LastName)
            .MaximumLength(50);

        RuleFor(r => r.UserForRegisterDto.Email)
            .NotEmpty()
            .NotNull();
        RuleFor(r => r.UserForRegisterDto.Email)
            .EmailAddress();
        RuleFor(r => r.UserForRegisterDto.Email)
            .MaximumLength(50);

        RuleFor(r => r.UserForRegisterDto.Password)
            .NotEmpty()
            .NotNull();
        RuleFor(r => r.UserForRegisterDto.Password)
            .MinimumLength(6);
        RuleFor(r => r.UserForRegisterDto.Password)
            .MaximumLength(25);
    }
}
