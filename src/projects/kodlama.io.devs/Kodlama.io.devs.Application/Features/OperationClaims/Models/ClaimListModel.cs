using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Models;

public sealed class ClaimListModel : BasePageableModel
{
    public IList<ClaimListDto> Items { get; set; }
}
