using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.devs.Application.Features.OperationClaims.Models;

namespace Kodlama.io.devs.Application.Features.OperationClaims.Profiles;

public sealed class ClaimProfiles : Profile
{
    public ClaimProfiles()
    {
        CreateMap<ClaimListDto, OperationClaim>().ReverseMap();

        CreateMap<IPaginate<OperationClaim>, ClaimListModel>();

        CreateMap<CreateOperationClaimCommand, OperationClaim>().ReverseMap();
        CreateMap<UpdateOperationClaimCommand, OperationClaim>().ReverseMap();

        CreateMap<CreatedOperationClaim, OperationClaim>().ReverseMap();
        CreateMap<UpdatedOperationClaim, OperationClaim>().ReverseMap();
    }
}
