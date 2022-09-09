using AutoMapper;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLangaugeTechnology;

public sealed class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProgrammingLanguageId { get; set; }

    public sealed class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules
                .ProgrammingLanguageTechnologyShouldExistsWhenRequested(request.Id);

            await _programmingLanguageTechnologyBusinessRules
                .ProgrammingLanguageTechnologyNameCannotBeDuplicatedWhenInsertedOrUpdated(request.Name);

            await _programmingLanguageTechnologyBusinessRules
                .ProgrammingLanguageShouldExistsWhenProgrammingLanguageTechnologyInsertedOrUpdated(request.ProgrammingLanguageId);

            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(
                p => p.Id == request.Id,
                cancellationToken: cancellationToken);

            _mapper.Map(request, programmingLanguageTechnology);

            ProgrammingLanguageTechnology updatedProgrammingLanguageRechnology = await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology, cancellationToken);

            UpdatedProgrammingLanguageTechnologyDto result = _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedProgrammingLanguageRechnology);
            return result;
        }
    }
}
