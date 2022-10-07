using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public sealed class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public sealed class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules
                .UserOperationClaimCannotBeDuplicatedWhenAddOrUpdate(request.UserId, request.OperationClaimId);

            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(userOperationClaim, cancellationToken);

            UpdatedUserOperationClaimDto response = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);

            return response;
        }
    }
}
