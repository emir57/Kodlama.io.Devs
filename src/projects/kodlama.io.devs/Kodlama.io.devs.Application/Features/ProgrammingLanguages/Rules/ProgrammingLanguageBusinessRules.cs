using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Rules;

public sealed class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task ProgrammingLanguageNameCannotBeDuplicatedWhenInsertedOrUpdated(string name)
    {
        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(
            p => p.Name.ToLower() == name.ToLower(),
            enableTracking: false);

        if (programmingLanguage != null)
            throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageCannotBeDuplicated);
    }

    public async Task ProgrammingLanguageShouldExistsWhenRequested(int id)
    {
        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(
            p => p.Id == id,
            enableTracking: false);

        if (programmingLanguage == null)
            throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNotExists);
    }
}
