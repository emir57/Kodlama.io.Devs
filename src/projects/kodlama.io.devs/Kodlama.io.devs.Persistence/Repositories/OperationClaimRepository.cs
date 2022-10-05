using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Persistence.Contexts;

namespace Kodlama.io.devs.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, KodlamaDevDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(KodlamaDevDbContext context) : base(context)
    {
    }
}
