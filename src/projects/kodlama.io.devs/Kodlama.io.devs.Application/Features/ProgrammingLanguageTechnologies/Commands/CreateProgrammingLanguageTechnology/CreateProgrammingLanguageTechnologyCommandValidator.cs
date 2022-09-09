using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;

public sealed class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommand>
{
    public CreateProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty();
        RuleFor(c => c.Name)
            .MaximumLength(50);
        RuleFor(c => c.Name)
            .MinimumLength(1);

        RuleFor(c => c.ProgrammingLanguageId)
            .NotNull()
            .NotEmpty();
        RuleFor(c => c.ProgrammingLanguageId)
            .GreaterThan(0);
    }
}
