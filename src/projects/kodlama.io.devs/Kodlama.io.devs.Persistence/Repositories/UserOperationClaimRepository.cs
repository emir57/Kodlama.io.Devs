using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, KodlamaDevDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(KodlamaDevDbContext context) : base(context)
    { }

    public async override Task<UserOperationClaim> AddAsync(UserOperationClaim entity, CancellationToken cancellationToken = default)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync(cancellationToken);
        UserOperationClaim? addedEntity = await GetAsync(u => u.Id == entity.Id,
            queryable => queryable.Include(u => u.User)
                                  .Include(u => u.OperationClaim), false, cancellationToken);

        return addedEntity;
    }
}
