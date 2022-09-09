using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Profiles;

public sealed class ProgrammingLanguageTechnologyProfiles : Profile
{
    public ProgrammingLanguageTechnologyProfiles()
    {
        CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyDto>().ReverseMap();
        CreateMap<ProgrammingLanguageTechnology, UpdateProgrammingLanguageTechnologyDto>().ReverseMap();

        CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();

        CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDto>()
            .ForMember(x => x.ProgrammingLanguageName, opt => opt.MapFrom(x => x.ProgrammingLanguage.Name))
            .ReverseMap();

        CreateMap<ProgrammingLanguageTechnology, GetByIdProgrammingLanguageTechnologyDto>()
            .ForMember(x => x.ProgrammingLanguageName, opt => opt.MapFrom(x => x.ProgrammingLanguage.Name))
            .ReverseMap();
    }
}
