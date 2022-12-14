using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLangaugeTechnology;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLangaugeTechnology;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Profiles;

public sealed class ProgrammingLanguageTechnologyProfiles : Profile
{
    public ProgrammingLanguageTechnologyProfiles()
    {
        CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommand>().ReverseMap();
        CreateMap<ProgrammingLanguageTechnology, UpdateProgrammingLanguageTechnologyCommand>().ReverseMap();
        CreateMap<ProgrammingLanguageTechnology, DeleteProgrammingLanguageTechnologyCommand>().ReverseMap();

        CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyDto>().ReverseMap();
        CreateMap<ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologyDto>().ReverseMap();
        CreateMap<ProgrammingLanguageTechnology, DeletedProgrammingLanguageTechnologyDto>().ReverseMap();

        CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();

        CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDto>()
            .ForMember(x => x.ProgrammingLanguageName, opt => opt.MapFrom(x => x.ProgrammingLanguage.Name))
            .ReverseMap();

        CreateMap<ProgrammingLanguageTechnology, GetByIdProgrammingLanguageTechnologyDto>()
            .ForMember(x => x.ProgrammingLanguageName, opt => opt.MapFrom(x => x.ProgrammingLanguage.Name))
            .ReverseMap();
    }
}
