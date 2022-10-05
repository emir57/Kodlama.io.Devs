using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.devs.Application.Services.Repositories;

public interface IOperationClaimRepository : IRepository<OperationClaim>, IAsyncRepository<OperationClaim>
{
}
