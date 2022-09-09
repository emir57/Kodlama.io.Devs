using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Persistence.Contexts;

namespace Kodlama.io.devs.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, KodlamaDevDbContext>, IUserRepository
{
    public UserRepository(KodlamaDevDbContext context) : base(context)
    {
    }
}
