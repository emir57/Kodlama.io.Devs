using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Kodlama.io.devs.Application.Features.GitHubs.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.devs.Application.Features.GitHubs.Commands.DeleteGitHub;

public sealed class DeleteGitHubCommand : IRequest<DeletedGitHubDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles =>
        new string[] { "User", "Admin" };

    public sealed class DeleteGitHubCommandHandler : IRequestHandler<DeleteGitHubCommand, DeletedGitHubDto>
    {
        private readonly IGitHubRepository _gitHubRepository;
        private readonly IMapper _mapper;
        private readonly GitHubBusinessRules _gitHubBusinessRules;

        public DeleteGitHubCommandHandler(IGitHubRepository gitHubRepository, IMapper mapper, GitHubBusinessRules gitHubBusinessRules)
        {
            _gitHubRepository = gitHubRepository;
            _mapper = mapper;
            _gitHubBusinessRules = gitHubBusinessRules;
        }

        public async Task<DeletedGitHubDto> Handle(DeleteGitHubCommand request, CancellationToken cancellationToken)
        {
            await _gitHubBusinessRules
                .GitHubShouldExistsWhenRequested(request.Id);

            GitHub? gitHub = await _gitHubRepository.GetAsync(
                x => x.Id == request.Id,
                enableTracking: false);

            GitHub? deletedGitHubEntity = await _gitHubRepository.HardDeleteAsync(gitHub, cancellationToken);

            DeletedGitHubDto deletedGitHubDto = _mapper.Map<DeletedGitHubDto>(deletedGitHubEntity);
            return deletedGitHubDto;
        }
    }
}
