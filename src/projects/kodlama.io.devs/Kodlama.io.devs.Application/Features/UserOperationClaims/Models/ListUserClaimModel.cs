using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Models;

public sealed class UserClaimListModel : BasePageableModel
{
    public IList<ListUserClaimDto> Items { get; set; }
}
