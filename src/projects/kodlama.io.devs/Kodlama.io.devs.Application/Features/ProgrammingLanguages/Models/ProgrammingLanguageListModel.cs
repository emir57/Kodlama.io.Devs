using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Dtos;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Models;

public sealed class ProgrammingLanguageListModel : BasePageableModel
{
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}
