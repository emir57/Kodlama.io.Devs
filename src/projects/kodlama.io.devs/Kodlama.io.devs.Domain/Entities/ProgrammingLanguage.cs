using Core.Persistence.Repositories;

namespace Kodlama.io.devs.Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public ProgrammingLanguage()
    {
    }

    public ProgrammingLanguage(int id) : base(id)
    {
    }

    public ProgrammingLanguage(int id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; }
}
