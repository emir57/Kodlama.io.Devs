using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;

public sealed class GetByIdProgrammingLanguageTechnologyQueryValidator : AbstractValidator<GetByIdProgrammingLanguageTechnologyQuery>
{
    public GetByIdProgrammingLanguageTechnologyQueryValidator()
    {
        RuleFor(g => g.Id)
            .NotEmpty()
            .NotNull();
    }
}
