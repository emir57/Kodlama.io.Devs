using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;

public sealed class ProgrammingLanguageTechnologyListModel : BasePageableModel
{
    public IList<ProgrammingLanguageTechnologyListDto> Items { get; set; }
}
