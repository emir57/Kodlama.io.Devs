using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Extensions;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Kodlama.io.devs.Application.Features.GitHubs.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.devs.Application.Features.GitHubs.Commands.CreateGitHub
{
    public sealed class CreateGitHubCommand : IRequest<CreatedGitHubDto>, ISecuredRequest
    {
        public string ProfileUserName { get; set; }

        public string[] Roles => new string[] { "User", "Admin" };

        public sealed class CreateGitHubCommandHandler : IRequestHandler<CreateGitHubCommand, CreatedGitHubDto>
        {
            private readonly IGitHubRepository _gitHubRepository;
            private readonly IMapper _mapper;
            private readonly GitHubBusinessRules _gitHubBusinessRules;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CreateGitHubCommandHandler(IGitHubRepository gitHubRepository, IMapper mapper, GitHubBusinessRules gitHubBusinessRules, IHttpContextAccessor httpContextAccessor)
            {
                _gitHubRepository = gitHubRepository;
                _mapper = mapper;
                _gitHubBusinessRules = gitHubBusinessRules;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CreatedGitHubDto> Handle(CreateGitHubCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                await _gitHubBusinessRules
                    .GitHubUserIdCannotBeDuplicateWhenInserted(userId);
                await _gitHubBusinessRules
                    .GitHubProfileNameCannotBeDuplicateWhenInserted(request.ProfileUserName);

                GitHub mappedGitHubEntity = _mapper.Map<GitHub>(request);
                mappedGitHubEntity.UserId = userId;

                GitHub addedGitHub = await _gitHubRepository.AddAsync(mappedGitHubEntity);

                CreatedGitHubDto result = _mapper.Map<CreatedGitHubDto>(addedGitHub);
                return result;
            }
        }
    }
}
