using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Queries.GetListClaims;

public sealed class GetListClaimsQuery : IRequest<ClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { "Admin" };

    public GetListClaimsQuery() { }
    public GetListClaimsQuery(PageRequest pageRequest) : this()
    {
        PageRequest = pageRequest;
    }

    public sealed class GetListClaimQueryHandler : IRequestHandler<GetListClaimsQuery, ClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<ClaimListModel> Handle(GetListClaimsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> list = await _operationClaimRepository.GetListAsync(
                enableTracking: false, cancellationToken: cancellationToken);

            ClaimListModel claimListModel = _mapper.Map<ClaimListModel>(list);

            return claimListModel;
        }
    }
}
