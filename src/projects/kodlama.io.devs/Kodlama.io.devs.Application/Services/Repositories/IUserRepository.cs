using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.devs.Application.Services.Repositories;

public interface IUserRepository : IRepository<User>, IAsyncRepository<User>
{
}
