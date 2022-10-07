using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.devs.Application.Services.Repositories;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Rules;

public sealed class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IUserRepository _userRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, IUserRepository userRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _operationClaimRepository = operationClaimRepository;
        _userRepository = userRepository;
    }

    public async Task UserOperationClaimCannotBeDuplicatedWhenAddOrUpdate(int userId, int operationClaimId)
    {
        UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(
            u => u.UserId == userId && u.OperationClaimId == operationClaimId,
            enableTracking: false);

        if (userOperationClaim is not null)
            throw new BusinessException(UserOperationClaimMessages.UserOperationClaimAlreadyExists);
    }

    public async Task OperationClaimShouldBeExists(int operationClaimId)
    {
        OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == operationClaimId, enableTracking: false);
        if (operationClaim is null)
            throw new BusinessException(UserOperationClaimMessages.OperationClaimShouldBeExists);
    }

    public async Task UserShouldBeExists(int userId)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == userId, enableTracking: false);
        if (user is null)
            throw new BusinessException(UserOperationClaimMessages.UserShouldBeExists);
    }
}
