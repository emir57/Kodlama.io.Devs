using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public sealed class GetByIdProgrammingLanguageQueryValidator : AbstractValidator<GetByIdProgrammingLanguageQuery>
{
    public GetByIdProgrammingLanguageQueryValidator()
    {
        RuleFor(g => g.Id)
            .NotEmpty()
            .NotNull();
    }
}
