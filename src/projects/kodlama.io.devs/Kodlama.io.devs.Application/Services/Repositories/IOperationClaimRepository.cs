using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.devs.Application.Services.Repositories;

public interface IOperationClaimRepository : IRepository<OperationClaim>, IAsyncRepository<OperationClaim>
{
    Task<IPaginate<OperationClaim>> GetByUserIdAsync(int userId, int index = 0, int size = 10, Func<IQueryable<OperationClaim>, IOrderedQueryable<OperationClaim>>? orderby = null, bool enableTracking = true, CancellationToken cancellationToken = default);
}
