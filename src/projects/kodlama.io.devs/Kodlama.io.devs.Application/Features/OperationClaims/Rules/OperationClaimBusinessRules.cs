using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.devs.Application.Services.Repositories;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Rules;

public sealed class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task OperationClaimNameCannotBeDuplicateWhenInsertedOrUpdated(string name)
    {
        OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name.ToLowerInvariant() == name.ToLowerInvariant());
        if (operationClaim != null)
            throw new BusinessException(OperationClaimMessages.OperationClaimNameCannotBeDuplicated);
    }
}
