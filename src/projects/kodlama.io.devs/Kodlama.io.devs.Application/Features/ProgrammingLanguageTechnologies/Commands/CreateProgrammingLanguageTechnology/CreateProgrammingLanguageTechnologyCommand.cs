using AutoMapper;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;

public sealed class CreateProgrammingLanguageTechnologyCommand : IRequest<CreatedProgrammingLanguageTechnologyDto>
{
    public string Name { get; set; }
    public int ProgrammingLangaugeId { get; set; }

    public sealed class CreateProgrammingLangaugeTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreatedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public CreateProgrammingLangaugeTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules
                .ProgrammingLanguageShouldExistsWhenProgrammingLanguageTechnologyInsertedOrUpdated(request.ProgrammingLangaugeId);
            
            await _programmingLanguageTechnologyBusinessRules
                .ProgrammingLanguageTechnologyNameCannotBeDuplicatedWhenInsertedOrUpdated(request.Name);
            ProgrammingLanguageTechnology mappedProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);

            ProgrammingLanguageTechnology addedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.AddAsync(mappedProgrammingLanguageTechnology);

            CreatedProgrammingLanguageTechnologyDto result = _mapper.Map<CreatedProgrammingLanguageTechnologyDto>(addedProgrammingLanguageTechnology);
            return result;
        }
    }
}
