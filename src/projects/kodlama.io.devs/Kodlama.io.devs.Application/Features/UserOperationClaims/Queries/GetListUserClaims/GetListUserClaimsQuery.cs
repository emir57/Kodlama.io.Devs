using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Queries.GetListUserClaims;

public sealed class GetListUserClaimsQuery : IRequest<UserClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public int UserId { get; set; }

    public string[] Roles => new[] { "Admin" };

    public GetListUserClaimsQuery() { }
    public GetListUserClaimsQuery(int userId, PageRequest pageRequest) : this()
    {
        UserId = userId;
        PageRequest = pageRequest;
    }

    public sealed class GetListUserClaimsQueryHandler : IRequestHandler<GetListUserClaimsQuery, UserClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserClaimsQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserClaimListModel> Handle(GetListUserClaimsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> list = await _operationClaimRepository.GetByUserIdAsync(
                userId: request.UserId,
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                orderby: (orderedQueryable) => orderedQueryable.OrderBy(o => o.Id),
                enableTracking: true);

            UserClaimListModel userClaimListModel = _mapper.Map<UserClaimListModel>(list);

            return userClaimListModel;
        }
    }
}
