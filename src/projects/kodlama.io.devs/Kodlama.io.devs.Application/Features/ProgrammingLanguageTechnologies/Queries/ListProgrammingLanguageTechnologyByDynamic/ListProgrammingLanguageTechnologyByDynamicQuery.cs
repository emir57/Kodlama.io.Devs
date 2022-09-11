using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.ListProgrammingLanguageTechnologyByDynamic;

public sealed class ListProgrammingLanguageTechnologyByDynamicQuery : IRequest<ProgrammingLanguageTechnologyListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public sealed class ListProgrammingLanguageTechnologyByDynamicQueryHandler : IRequestHandler<ListProgrammingLanguageTechnologyByDynamicQuery, ProgrammingLanguageTechnologyListModel>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public ListProgrammingLanguageTechnologyByDynamicQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(ListProgrammingLanguageTechnologyByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguageTechnology> list = await _programmingLanguageTechnologyRepository
                .GetListByDynamicAsync(request.Dynamic,
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                enableTracking: false);

            ProgrammingLanguageTechnologyListModel result = _mapper.Map<ProgrammingLanguageTechnologyListModel>(list);
            return result;
        }
    }
}
