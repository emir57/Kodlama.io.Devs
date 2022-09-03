using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Name)
                .MaximumLength(50);

            RuleFor(c => c.Name)
                .MinimumLength(1);
        }
    }
}
