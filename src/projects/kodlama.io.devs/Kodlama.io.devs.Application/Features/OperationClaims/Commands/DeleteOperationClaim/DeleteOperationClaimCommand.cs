using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public sealed class DeleteOperationClaimCommand : IRequest<DeletedOperationClaim>
{
    public int Id { get; set; }

    public sealed class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaim>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeletedOperationClaim> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules
                .OperationClaimShouldBeExistsWhenRequested(request.Id);

            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

            OperationClaim deletedOperationClaim = await _operationClaimRepository.HardDeleteAsync(operationClaim);

            DeletedOperationClaim response = _mapper.Map<DeletedOperationClaim>(deletedOperationClaim);

            return response;
        }
    }
}
