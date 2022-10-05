using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.devs.Application.Features.Authorizations.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.devs.Application.Features.Authorizations.Commands.Login;

public sealed class LoginCommand : IRequest<AccessToken>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly AuthorizationBusinessRules _authorizationBusinessRules;

        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, AuthorizationBusinessRules authorizationBusinessRules, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authorizationBusinessRules = authorizationBusinessRules;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            await _authorizationBusinessRules
                .UserShouldExistsWhenLogin(request.UserForLoginDto.Email);

            User? user = await _userRepository.GetAsync(
                u => u.Email.ToLower() == request.UserForLoginDto.Email.ToLower(),
                include: x => x.Include(u => u.UserOperationClaims)
                               .ThenInclude(u => u.OperationClaim),
                enableTracking: false);

            _authorizationBusinessRules.VerifyPassword(request.UserForLoginDto, user);

            List<OperationClaim> operationClaims = userOperationClaims(user).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        private IEnumerable<OperationClaim> userOperationClaims(User user)
        {
            foreach (UserOperationClaim userOperationClaim in user.UserOperationClaims)
                yield return new OperationClaim()
                {
                    Name = userOperationClaim.OperationClaim.Name
                };
        }
    }
}
