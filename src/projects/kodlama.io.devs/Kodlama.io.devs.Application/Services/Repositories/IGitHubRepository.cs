using Core.Persistence.Repositories;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Services.Repositories;

public interface IGitHubRepository : IRepository<GitHub>,IAsyncRepository<GitHub>
{
}
