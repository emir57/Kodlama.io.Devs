using Core.Persistence.Repositories;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using Kodlama.io.devs.Persistence.Contexts;

namespace Kodlama.io.devs.Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, KodlamaDevDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(KodlamaDevDbContext context) : base(context)
        {
        }
    }
}
