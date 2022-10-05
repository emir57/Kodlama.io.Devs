using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public sealed class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaim>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public sealed class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaim>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdatedOperationClaim> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            //todo: check exists

            await _operationClaimBusinessRules
                .OperationClaimNameCannotBeDuplicateWhenInsertedOrUpdated(request.Name);

            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

            OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim, cancellationToken);

            UpdatedOperationClaim response = _mapper.Map<UpdatedOperationClaim>(updatedOperationClaim);

            return response;
        }
    }
}
