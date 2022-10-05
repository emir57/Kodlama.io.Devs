using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public sealed class CreateOperationClaimCommand : IRequest<CreatedOperationClaim>
{
    public string Name { get; set; }

    public sealed class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaim>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreatedOperationClaim> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            //todo: not duplicate when inserted

            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

            OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(operationClaim, cancellationToken);

            CreatedOperationClaim createdOperationClaim = _mapper.Map<CreatedOperationClaim>(addedOperationClaim);

            return createdOperationClaim;
        }
    }
}
