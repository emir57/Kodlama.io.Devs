using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCannotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Name.ToLower() == name.ToLower());
            if (programmingLanguage == null)
                throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageCannotBeDuplicated); ;
        }

        public async Task ProgrammingLanguageShouldExistsWhenRequested(int id)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == id);
            if (programmingLanguage == null)
                throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNotExists);
        }
    }
}
