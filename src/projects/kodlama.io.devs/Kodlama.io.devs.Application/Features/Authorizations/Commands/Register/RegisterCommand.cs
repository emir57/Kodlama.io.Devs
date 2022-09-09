using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.devs.Application.Features.Authorizations.Commands.Login;
using Kodlama.io.devs.Application.Features.Authorizations.Rules;
using Kodlama.io.devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.devs.Application.Features.Authorizations.Commands.Register;

public sealed class RegisterCommand : IRequest<AccessToken>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }

    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthorizationBusinessRules _authorizationBusinessRules;
        private readonly IMediator _mediator;

        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, AuthorizationBusinessRules authorizationBusinessRules, IMediator mediator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authorizationBusinessRules = authorizationBusinessRules;
            _mediator = mediator;
        }

        public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authorizationBusinessRules
                .UserShouldNotExistsWhenRegister(request.UserForRegisterDto.Email);

            await addUserAsync(request.UserForRegisterDto, cancellationToken);

            UserForLoginDto userForLoginDto = _mapper.Map<UserForLoginDto>(request.UserForRegisterDto);
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto };

            AccessToken accessToken = await _mediator.Send(loginCommand, cancellationToken);
            return accessToken;
        }

        private async Task<User> addUserAsync(UserForRegisterDto userForRegisterDto, CancellationToken cancellationToken = default)
        {
            User user = new();
            setPassword(userForRegisterDto, out user);

            User addedUser = await _userRepository.AddAsync(user, cancellationToken);

            User updatedUser = await addUserRoleAsync(addedUser, cancellationToken);
            return updatedUser;

            async Task<User> addUserRoleAsync(User user, CancellationToken cancellationToken = default)
            {
                user.UserOperationClaims.Add(new UserOperationClaim
                {
                    UserId = user.Id,
                    OperationClaimId = 1
                });

                User updatedUser = await _userRepository.UpdateAsync(user, cancellationToken);
                return updatedUser;
            }
            void setPassword(UserForRegisterDto userForRegisterDto, out User user)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

                user = _mapper.Map<User>(userForRegisterDto);
                user.Status = true;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.AuthenticatorType = AuthenticatorType.Email;
            }
        }
    }
}
