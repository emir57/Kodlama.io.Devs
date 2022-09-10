using AutoMapper;
using Kodlama.io.devs.Application.Features.GitHubs.Commands.CreateGitHub;
using Kodlama.io.devs.Application.Features.GitHubs.Commands.UpdateGitHub;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.GitHubs.Profiles;

public sealed class GitHubProfiles : Profile
{
    public GitHubProfiles()
    {
        CreateMap<GitHub, CreateGitHubCommand>().ReverseMap();
        CreateMap<GitHub, UpdateGitHubCommand>();
        CreateMap<UpdateGitHubCommand, GitHub>()
            .ForMember(x => x.UserId, opt => opt.Ignore())
            .ForMember(x => x.CreatedAt, opt => opt.Ignore())
            .ForMember(x => x.UpdatedAt, opt => opt.Ignore())
            .ForMember(x => x.DeletedAt, opt => opt.Ignore());


        CreateMap<GitHub, UpdatedGitHubDto>().ReverseMap();
        CreateMap<GitHub, CreatedGitHubDto>().ReverseMap();
    }
}
