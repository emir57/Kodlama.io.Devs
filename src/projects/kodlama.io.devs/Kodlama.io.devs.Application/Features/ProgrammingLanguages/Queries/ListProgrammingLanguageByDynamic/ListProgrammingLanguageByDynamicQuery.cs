using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Queries.ListProgrammingLanguageByDynamic;

public sealed class ListProgrammingLanguageByDynamicQuery : IRequest<ProgrammingLanguageListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public sealed class ListProgrammingLanguageByDynamicQueryHandler : IRequestHandler<ListProgrammingLanguageByDynamicQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public ListProgrammingLanguageByDynamicQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(ListProgrammingLanguageByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> list = await _programmingLanguageRepository.GetListByDynamicAsync(
                request.Dynamic,
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                enableTracking: false);

            ProgrammingLanguageListModel result = _mapper.Map<ProgrammingLanguageListModel>(list);
            return result;

        }
    }
}
