using Core.Persistence.Repositories;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using Kodlama.io.devs.Persistence.Contexts;

namespace Kodlama.io.devs.Persistence.Repositories;

public class GitHubRepository : EfRepositoryBase<GitHub, KodlamaDevDbContext>, IGitHubRepository
{
    public GitHubRepository(KodlamaDevDbContext context) : base(context)
    {
    }
}
