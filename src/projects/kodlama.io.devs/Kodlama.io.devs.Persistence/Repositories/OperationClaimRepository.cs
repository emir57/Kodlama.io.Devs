using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, KodlamaDevDbContext>, IOperationClaimRepository
{
    private readonly KodlamaDevDbContext _context;
    public OperationClaimRepository(KodlamaDevDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IPaginate<OperationClaim>> GetByUserIdAsync(int userId, int index = 0, int size = 10, Func<IQueryable<OperationClaim>, IOrderedQueryable<OperationClaim>>? orderby = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<OperationClaim> operationClaimsQueryable = from uoc in _context.UserOperationClaims
                                                              join oc in _context.OperationClaims
                                                              on uoc.OperationClaimId equals oc.Id
                                                              where uoc.UserId == userId
                                                              select new OperationClaim
                                                              {
                                                                  Id = oc.Id,
                                                                  Name = oc.Name
                                                              };
        if (enableTracking == false)
            operationClaimsQueryable = operationClaimsQueryable.AsNoTracking();

        if (orderby != null)
            return await orderby(operationClaimsQueryable).ToPaginateAsync(index, size, cancellationToken: cancellationToken);

        return await operationClaimsQueryable.OrderBy(o => o.Id).ToPaginateAsync(index, size, cancellationToken: cancellationToken);
    }
}
