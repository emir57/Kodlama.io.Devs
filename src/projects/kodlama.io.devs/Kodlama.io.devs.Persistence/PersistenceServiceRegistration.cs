using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Persistence.Contexts;
using Kodlama.io.devs.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.devs.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        #region Context
        services.AddDbContext<KodlamaDevDbContext>();
        #endregion

        #region Repositories
        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        services.AddScoped<IProgrammingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGitHubRepository, GitHubRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        #endregion

        return services;
    }
}
