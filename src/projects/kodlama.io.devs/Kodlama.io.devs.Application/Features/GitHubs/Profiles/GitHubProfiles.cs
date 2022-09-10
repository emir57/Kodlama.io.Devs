using AutoMapper;
using Kodlama.io.devs.Application.Features.GitHubs.Commands.CreateGitHub;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.GitHubs.Profiles;

public sealed class GitHubProfiles : Profile
{
    public GitHubProfiles()
    {
        CreateMap<GitHub, CreateGitHubCommand>().ReverseMap();

        CreateMap<GitHub, CreatedGitHubDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(g => $"{g.User.FirstName} {g.User.LastName}"))
            .ForMember(x => x.Email, opt => opt.MapFrom(g => g.User.Email))
            .ReverseMap();
    }
}
