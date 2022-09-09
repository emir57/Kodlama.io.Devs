using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Kodlama.io.devs.Application.Features.Authorizations.Commands.Login;

public sealed class LoginCommand : IRequest<AccessToken>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
    {
        public Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
