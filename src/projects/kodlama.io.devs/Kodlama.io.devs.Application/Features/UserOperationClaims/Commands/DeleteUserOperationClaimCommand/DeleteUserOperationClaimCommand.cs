using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand;

public sealed class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public DeleteUserOperationClaimCommand() { }
    public DeleteUserOperationClaimCommand(int userId, int operationClaimId) : this()
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }

    public sealed class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules
                .UserShouldBeExists(request.UserId);

            await _userOperationClaimBusinessRules
                .OperationClaimShouldBeExists(request.OperationClaimId);

            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(
                u => u.UserId == request.UserId && u.OperationClaimId == request.OperationClaimId,
                include: queryable => queryable
                                        .Include(x => x.User)
                                        .Include(x => x.OperationClaim),
                    enableTracking: false,
                    cancellationToken);

            UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.HardDeleteAsync(userOperationClaim, cancellationToken);

            DeletedUserOperationClaimDto response = _mapper.Map<DeletedUserOperationClaimDto>(userOperationClaim);

            return response;
        }
    }
}
