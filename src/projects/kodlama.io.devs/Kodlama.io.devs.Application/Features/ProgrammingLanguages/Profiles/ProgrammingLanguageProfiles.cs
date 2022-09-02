using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.devs.Domain.Entities;

namespace Kodlama.io.devs.Application.Features.ProgrammingLanguages.Profiles
{
    public class ProgrammingLanguageProfiles : Profile
    {
        public ProgrammingLanguageProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        }
    }
}
