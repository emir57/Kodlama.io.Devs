using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Persistence.Contexts;
using Kodlama.io.devs.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<KodlamaDevDbContext>();

            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();

            return services;
        }
    }
}
