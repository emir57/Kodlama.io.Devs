using Core.Persistence.Repositories;

namespace Kodlama.io.devs.Domain.Entities;

public sealed class ProgrammingLanguageTechnology : Entity
{
    public string Name { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public ProgrammingLanguageTechnology()
    {
        new ProgrammingLanguage();
    }

    public ProgrammingLanguageTechnology(int id, string name, int programmingLanguageId, DateTime createdAt) : this()
    {
        Id = id;
        Name = name;
        ProgrammingLanguageId = programmingLanguageId;
        CreatedAt = createdAt;
    }
}
