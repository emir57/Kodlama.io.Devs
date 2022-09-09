using Core.Persistence.Repositories;
using Kodlama.io.devs.Application.Services.Repositories;
using Kodlama.io.devs.Domain.Entities;
using Kodlama.io.devs.Persistence.Contexts;

namespace Kodlama.io.devs.Persistence.Repositories;

public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology, KodlamaDevDbContext>, IProgrammingLanguageTechnologyRepository
{
    public ProgrammingLanguageTechnologyRepository(KodlamaDevDbContext context) : base(context)
    {
    }
}
