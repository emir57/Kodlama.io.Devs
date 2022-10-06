using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.AddUserOperationClaim;

public sealed class AddUserOperationClaimCommand : IRequest<AddedUserOperationClaimDto>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public sealed class AddUserOperationClaimCommandHandler : IRequestHandler<AddUserOperationClaimCommand, AddedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public AddUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<AddedUserOperationClaimDto> Handle(AddUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim, cancellationToken);

            AddedUserOperationClaimDto response = _mapper.Map<AddedUserOperationClaimDto>(addedUserOperationClaim);

            return response;
        }
    }
}
