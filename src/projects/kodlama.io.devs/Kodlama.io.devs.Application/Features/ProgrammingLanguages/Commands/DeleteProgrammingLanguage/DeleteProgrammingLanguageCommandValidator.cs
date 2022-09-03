﻿using FluentValidation;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
