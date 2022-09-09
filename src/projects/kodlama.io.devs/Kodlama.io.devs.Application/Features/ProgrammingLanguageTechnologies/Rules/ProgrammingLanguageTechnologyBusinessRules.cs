using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Constants;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Rules;

public sealed class ProgrammingLanguageTechnologyBusinessRules
{
    private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

    public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
    {
        _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
    }

    public async Task ProgrammingLanguageTechnologyShouldExistsWhenRequested(int id)
    {
        ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(
            p => p.Id == id,
            enableTracking: false);

        if (programmingLanguageTechnology == null)
            throw new BusinessException(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageTechnologyNotExists);
    }
}
