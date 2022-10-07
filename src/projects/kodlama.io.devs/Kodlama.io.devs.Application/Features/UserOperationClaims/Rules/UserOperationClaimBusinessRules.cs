using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.devs.Application.Services.Repositories;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Rules;

public sealed class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task UserOperationClaimCannotBeDuplicatedWhenAddOrUpdate(int userId, int operationClaimId)
    {
        UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(
            u => u.UserId == userId && u.OperationClaimId == operationClaimId,
            enableTracking: false);

        if (userOperationClaim is not null)
            throw new BusinessException(UserOperationClaimMessages.UserOperationClaimAlreadyExists);
    }
}
