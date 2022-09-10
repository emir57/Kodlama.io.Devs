using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using Kodlama.io.devs.Application.Features.GitHubs.Constants;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Kodlama.io.devs.Application.Features.GitHubs.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Application.Features.GitHubs.Queries;

public sealed class GetByUserIdGitHubQuery : IRequest<GetByUserIdGitHubDto>, ISecuredRequest
{

    public string[] Roles =>
        new string[] { "User", "Admin" };

    public sealed class GetByUserIdGitHubQueryHandler : IRequestHandler<GetByUserIdGitHubQuery, GetByUserIdGitHubDto>
    {
        private readonly IGitHubRepository _gitHubRepository;
        private readonly IMapper _mapper;
        private readonly GitHubBusinessRules _gitHubBusinessRules;
        private readonly int _userId;

        public GetByUserIdGitHubQueryHandler(IGitHubRepository gitHubRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _gitHubRepository = gitHubRepository;
            _mapper = mapper;
            _userId = httpContextAccessor.HttpContext.User.GetUserId();
        }

        public async Task<GetByUserIdGitHubDto> Handle(GetByUserIdGitHubQuery request, CancellationToken cancellationToken)
        {
            GitHub? gitHub = await _gitHubRepository.GetAsync(
                x => x.UserId == _userId,
                include: x => x.Include(u => u.User),
                enableTracking: false);
            if (gitHub == null)
                throw new BusinessException(GitHubMessages.GitHubNotExists);

            GetByUserIdGitHubDto getByUserIdGitHubDto = _mapper.Map<GetByUserIdGitHubDto>(gitHub);
            return getByUserIdGitHubDto;
        }
    }
}
