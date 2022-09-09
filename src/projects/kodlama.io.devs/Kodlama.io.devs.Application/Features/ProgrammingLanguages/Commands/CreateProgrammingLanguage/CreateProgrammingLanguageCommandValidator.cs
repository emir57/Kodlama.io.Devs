using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public sealed class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Name)
            .MaximumLength(50);

        RuleFor(c => c.Name)
            .MinimumLength(1);
    }
}
