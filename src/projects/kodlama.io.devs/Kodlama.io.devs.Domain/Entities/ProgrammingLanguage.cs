using Core.Persistence.Repositories;

namespace Kodlama.io.devs.Domain.Entities;

public sealed class ProgrammingLanguage : Entity
{
    public string Name { get; set; }
    public ICollection<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

    public ProgrammingLanguage()
    {
        ProgrammingLanguageTechnologies = new HashSet<ProgrammingLanguageTechnology>();
    }

    public ProgrammingLanguage(int id) : this()
    {
        Id = id;
    }

    public ProgrammingLanguage(int id, string name) : this(id)
    {
        Name = name;
    }
    public ProgrammingLanguage(int id, string name, DateTime createdAt) : this(id, name)
    {
        CreatedAt = createdAt;
    }
}
