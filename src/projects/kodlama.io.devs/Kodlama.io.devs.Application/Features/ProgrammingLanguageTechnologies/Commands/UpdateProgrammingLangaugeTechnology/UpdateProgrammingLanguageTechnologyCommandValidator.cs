using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLangaugeTechnology;

public sealed class UpdateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
{
    public UpdateProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotNull()
            .NotEmpty();
        RuleFor(u => u.Id)
            .GreaterThan(0);

        RuleFor(u => u.Name)
            .NotNull()
            .NotEmpty();
        RuleFor(u => u.Name)
            .MaximumLength(50);
        RuleFor(u => u.Name)
            .MinimumLength(1);

        RuleFor(u => u.ProgrammingLanguageId)
            .NotNull()
            .NotEmpty();
        RuleFor(u => u.ProgrammingLanguageId)
            .GreaterThan(0);
    }
}
