using FluentValidation;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Queries.GetListUserClaims;

public sealed class GetListUserClaimQueryValidator : AbstractValidator<GetListUserClaimsQuery>
{
    public GetListUserClaimQueryValidator()
    {
        RuleFor(g => g.UserId)
            .NotEmpty()
            .NotNull();
    }
}
