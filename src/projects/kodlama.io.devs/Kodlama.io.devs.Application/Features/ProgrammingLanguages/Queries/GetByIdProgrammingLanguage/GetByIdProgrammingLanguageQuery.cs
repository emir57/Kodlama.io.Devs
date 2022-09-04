using AutoMapper;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQuery : IRequest<GetByIdProgrammingLanguageDto>
{
    public int Id { get; set; }

    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetByIdProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageRules;

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageRules = programmingLanguageRules;
        }

        public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            await _programmingLanguageRules
                .ProgrammingLanguageShouldExistsWhenRequested(request.Id);

            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

            GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = _mapper.Map<GetByIdProgrammingLanguageDto>(programmingLanguage);
            return getByIdProgrammingLanguageDto;
        }
    }
}
