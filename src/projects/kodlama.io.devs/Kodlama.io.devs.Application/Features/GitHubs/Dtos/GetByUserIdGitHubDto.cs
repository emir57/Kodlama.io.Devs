namespace Kodlama.io.devs.Application.Features.GitHubs.Dtos;

public sealed class GetByUserGitHubDto
{
    public int Id { get; set; }
    public string ProfileUserName { get; set; }
    public string UserFullName { get; set; }
    public string UserEmail { get; set; }
}
