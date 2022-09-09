using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using MediatR;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.ListProgrammingLanguageTechnology;

public sealed class ListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>
{

    public sealed class ListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<ListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
    {
        public Task<ProgrammingLanguageTechnologyListModel> Handle(ListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
