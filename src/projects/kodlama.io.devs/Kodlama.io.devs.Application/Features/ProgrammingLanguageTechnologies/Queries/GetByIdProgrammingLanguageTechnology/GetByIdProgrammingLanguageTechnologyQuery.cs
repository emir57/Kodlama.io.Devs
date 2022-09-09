using AutoMapper;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;

public sealed class GetByIdProgrammingLanguageTechnologyQuery : IRequest<GetByIdProgrammingLanguageTechnologyDto>
{
    public int Id { get; set; }

    public sealed class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, GetByIdProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _rogrammingLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetByIdProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository rogrammingLanguageTechnologyRepository, IMapper mapper)
        {
            _rogrammingLanguageTechnologyRepository = rogrammingLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProgrammingLanguageTechnologyDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            //todo: check null
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _rogrammingLanguageTechnologyRepository.GetAsync(
                p => p.Id == request.Id,
                include: x => x.Include(p => p.ProgrammingLanguage),
                enableTracking: false,
                cancellationToken: cancellationToken);

            GetByIdProgrammingLanguageTechnologyDto result = _mapper.Map<GetByIdProgrammingLanguageTechnologyDto>(programmingLanguageTechnology);
            return result;
        }
    }
}
