using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Kodlama.io.devs.Application.Features.GitHubs.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.devs.Application.Features.GitHubs.Commands.UpdateGitHub;

public sealed class UpdateGitHubCommand : IRequest<UpdatedGitHubDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string ProfileUserName { get; set; }

    public string[] Roles => new string[] { "User", "Admin" };

    public sealed class UpdateGitHubCommandHandler : IRequestHandler<UpdateGitHubCommand, UpdatedGitHubDto>
    {
        private readonly IGitHubRepository _gitHubRepository;
        private readonly IMapper _mapper;
        private readonly GitHubBusinessRules _gitHubBusinessRules;
        public UpdateGitHubCommandHandler(IGitHubRepository gitHubRepository, IMapper mapper, GitHubBusinessRules gitHubBusinessRules)
        {
            _gitHubRepository = gitHubRepository;
            _mapper = mapper;
            _gitHubBusinessRules = gitHubBusinessRules;
        }

        public async Task<UpdatedGitHubDto> Handle(UpdateGitHubCommand request, CancellationToken cancellationToken)
        {
            await _gitHubBusinessRules
                .GitHubShouldExistsWhenRequested(request.Id);

            await _gitHubBusinessRules
                .GitHubUserIdCannotBeDuplicateWhenInserted(request.Id);

            GitHub? gitHub = await _gitHubRepository.GetAsync(
                x => x.Id == request.Id);
            _mapper.Map(request, gitHub);

            GitHub updatedGitHubEntity = await _gitHubRepository.UpdateAsync(gitHub);
            UpdatedGitHubDto updatedGitHubDto = _mapper.Map<UpdatedGitHubDto>(updatedGitHubEntity);
            return updatedGitHubDto;
        }
    }
}
