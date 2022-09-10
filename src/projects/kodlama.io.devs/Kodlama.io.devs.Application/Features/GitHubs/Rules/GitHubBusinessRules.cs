using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.devs.Application.Features.GitHubs.Constants;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.GitHubs.Rules
{
    public sealed class GitHubBusinessRules
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubBusinessRules(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public async Task GitHubProfileNameCannotBeDuplicateWhenInserted(string profileUserName)
        {
            GitHub? gitHub = await _gitHubRepository.GetAsync(
                x => x.ProfileUserName.ToLower() == profileUserName.ToLower(),
                enableTracking: false);
            if (gitHub != null)
                throw new BusinessException(GitHubMessages.GitHubProfileNameCannotBeDuplicated);
        }
        public async Task GitHubUserIdCannotBeDuplicateWhenInserted(int userId)
        {
            GitHub? gitHub = await _gitHubRepository.GetAsync(
                x => x.UserId == userId,
                 enableTracking: false);
            if (gitHub != null)
                throw new BusinessException(GitHubMessages.GitHubUserIdCannotBeDuplicated);
        }

        public async Task GitHubShouldExistsWhenRequested(int id)
        {
            GitHub? gitHub = await _gitHubRepository.GetAsync(
                x => x.Id == id,
                enableTracking: false);
            if (gitHub == null)
                throw new BusinessException(GitHubMessages.GitHubNotExists);
        }

    }
}
