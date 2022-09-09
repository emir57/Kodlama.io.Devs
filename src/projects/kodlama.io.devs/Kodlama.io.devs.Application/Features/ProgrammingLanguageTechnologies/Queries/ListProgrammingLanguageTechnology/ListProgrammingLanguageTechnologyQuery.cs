using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.ListProgrammingLanguageTechnology;

public sealed class ListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
    public sealed class ListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<ListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public ListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(ListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguageTechnology> paginate = await _programmingLanguageTechnologyRepository.GetListAsync(
                include: x => x.Include(x => x.ProgrammingLanguage),
                index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            ProgrammingLanguageTechnologyListModel result = _mapper.Map<ProgrammingLanguageTechnologyListModel>(paginate);
            return result;
        }
    }
}
