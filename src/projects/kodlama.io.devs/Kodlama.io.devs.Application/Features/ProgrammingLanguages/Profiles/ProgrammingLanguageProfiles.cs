using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Profiles;

public sealed class ProgrammingLanguageProfiles : Profile
{
    public ProgrammingLanguageProfiles()
    {
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();


        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
    }
}
