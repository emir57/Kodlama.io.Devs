using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public sealed class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { "Admin" };

    public sealed class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules
                .UserShouldBeExists(request.UserId);

            await _userOperationClaimBusinessRules
                .OperationClaimShouldBeExists(request.OperationClaimId);

            await _userOperationClaimBusinessRules
                .UserOperationClaimCannotBeDuplicatedWhenAddOrUpdate(request.UserId, request.OperationClaimId);

            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim, cancellationToken);

            CreatedUserOperationClaimDto response = _mapper.Map<CreatedUserOperationClaimDto>(addedUserOperationClaim);

            return response;
        }
    }
}
