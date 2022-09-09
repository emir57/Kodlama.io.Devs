using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public sealed class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(d => d.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(d => d.Name)
            .MaximumLength(50);

        RuleFor(d => d.Name)
            .MinimumLength(1);
    }
}
