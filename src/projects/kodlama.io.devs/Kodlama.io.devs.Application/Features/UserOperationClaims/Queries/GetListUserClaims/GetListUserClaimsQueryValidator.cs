using FluentValidation;

namespace Kodlama.io.devs.Application.Features.UserOperationClaims.Queries.GetListUserClaims;

public sealed class GetListUserClaimsQueryValidator : AbstractValidator<GetListUserClaimsQuery>
{
    public GetListUserClaimsQueryValidator()
    {
        RuleFor(g => g.UserId)
            .NotEmpty()
            .NotNull();
    }
}
