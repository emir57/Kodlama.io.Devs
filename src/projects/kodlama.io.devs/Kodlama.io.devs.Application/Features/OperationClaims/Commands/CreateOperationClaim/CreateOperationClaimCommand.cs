using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public sealed class CreateOperationClaimCommand : IRequest<CreatedOperationClaim>, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { "Admin" };

    public sealed class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaim>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<CreatedOperationClaim> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules
                .OperationClaimNameCannotBeDuplicateWhenInsertedOrUpdated(request.Name);

            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

            OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(operationClaim, cancellationToken);

            CreatedOperationClaim createdOperationClaim = _mapper.Map<CreatedOperationClaim>(addedOperationClaim);

            return createdOperationClaim;
        }
    }
}
