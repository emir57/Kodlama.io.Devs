using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace Kodlama.io.devs.Application.Features.Authorizations.Profiles;

public sealed class AuthorizationProfiles : Profile
{
    public AuthorizationProfiles()
    {
        CreateMap<User, UserForRegisterDto>().ReverseMap();
        CreateMap<UserForLoginDto, UserForRegisterDto>().ReverseMap();
    }
}
