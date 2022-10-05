using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Queries.GetByUserIdClaim;

public sealed class GetByUserIdClaimsQuery : IRequest<ClaimListModel>
{
    public PageRequest PageRequest { get; set; }
    public int UserId { get; set; }

    public sealed class GetByUserIdClaimsQueryHandler : IRequestHandler<GetByUserIdClaimsQuery, ClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetByUserIdClaimsQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<ClaimListModel> Handle(GetByUserIdClaimsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> list = await _operationClaimRepository.GetByUserIdAsync(
                userId: request.UserId,
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                orderby: (orderedQueryable) => orderedQueryable.OrderBy(o => o.Id),
                enableTracking: true);

            ClaimListModel claimListModel = _mapper.Map<ClaimListModel>(list);

            return claimListModel;
        }
    }
}
