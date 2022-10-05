using Kodlama.io.devs.Application.Features.OperationClaims.Models;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Queries.GetByUserIdClaim;

public sealed class GetByUserIdClaimsQuery : IRequest<ClaimListModel>
{
    public int UserId { get; set; }

    public sealed class GetByUserIdClaimsQueryHandler : IRequestHandler<GetByUserIdClaimsQuery, ClaimListModel>
    {
        private readonly 

        public async Task<ClaimListModel> Handle(GetByUserIdClaimsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult<ClaimListModel>(null);
        }
    }
}
