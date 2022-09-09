using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Constants;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Rules;

public sealed class ProgrammingLanguageTechnologyBusinessRules
{
    private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task ProgrammingLanguageTechnologyShouldExistsWhenRequested(int id)
    {
        ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(
            p => p.Id == id,
            enableTracking: false);

        if (programmingLanguageTechnology == null)
            throw new BusinessException(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageTechnologyNotExists);
    }

    public async Task ProgrammingLanguageShouldExistsWhenProgrammingLanguageTechnologyInsertedOrUpdated(int programmingLanguageId)
    {
        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(
            p => p.Id == programmingLanguageId,
            enableTracking: false);

        if (programmingLanguage == null)
            throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNotExists);
    }

    public async Task ProgrammingLanguageTechnologyNameCannotBeDuplicatedWhenInsertedOrUpdated(string name)
    {
        ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(
            p => p.Name.ToLower() == name.ToLower(),
            enableTracking: false);

        if (programmingLanguageTechnology != null)
            throw new BusinessException(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageTechnologyCannotBeDuplicated);
    }
}
