using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Kodlama.io.devs.Application.Features.UserOperationClaims.Dtos;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Profiles;

public sealed class UserOperationClaimProfiles : Profile
{
    public UserOperationClaimProfiles()
    {
        CreateMap<CreateUserOperationClaimCommand, UserOperationClaim>().ReverseMap();
        CreateMap<UpdateUserOperationClaimCommand, UserOperationClaim>().ReverseMap();
        CreateMap<DeleteUserOperationClaimCommand, UserOperationClaim>().ReverseMap();

        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>()
            .ForMember(x => x.OperationClaimName, opt => opt.MapFrom(x => x.OperationClaim.Name))
            .ForMember(x => x.UserEmail, opt => opt.MapFrom(x => x.User.Email))
            .ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>()
            .ForMember(x => x.UserEmail, opt => opt.MapFrom(x => x.User.Email))
            .ForMember(x => x.OperationClaimName, opt => opt.MapFrom(x => x.OperationClaim.Name))
            .ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>()
            .ForMember(x => x.UserEmail, opt => opt.MapFrom(x => x.User.Email))
            .ForMember(x => x.OperationClaimName, opt => opt.MapFrom(x => x.OperationClaim.Name))
            .ReverseMap();

    }
}
