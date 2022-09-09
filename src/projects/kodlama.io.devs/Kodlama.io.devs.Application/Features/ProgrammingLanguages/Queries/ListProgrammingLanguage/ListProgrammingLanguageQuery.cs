using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Queries.ListProgrammingLanguage;

public sealed class ListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    public sealed class ListProgrammingLanguageQueryHandler : IRequestHandler<ListProgrammingLanguageQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public ListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(ListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> paginate = await _programmingLanguageRepository.GetListAsync(
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                enableTracking: false,
                cancellationToken: cancellationToken);

            ProgrammingLanguageListModel programmingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(paginate);
            return programmingLanguageListModel;
        }
    }
}
