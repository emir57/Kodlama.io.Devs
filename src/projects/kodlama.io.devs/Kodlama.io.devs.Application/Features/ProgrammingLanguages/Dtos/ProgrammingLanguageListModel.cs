using Core.Persistence.Paging;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Dtos
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
