using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLangaugeTechnology;

public sealed class DeleteProgrammingLanguageTechnologyCommandValidator : AbstractValidator<DeleteProgrammingLanguageTechnologyCommand>
{
    public DeleteProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull();
        RuleFor(d => d.Id)
            .GreaterThan(0);
    }
}
