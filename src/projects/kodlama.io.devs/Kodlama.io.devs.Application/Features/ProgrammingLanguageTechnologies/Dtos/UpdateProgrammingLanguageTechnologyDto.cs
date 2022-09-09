namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

public sealed class UpdateProgrammingLanguageTechnologyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProgrammingLanguageId { get; set; }
}
