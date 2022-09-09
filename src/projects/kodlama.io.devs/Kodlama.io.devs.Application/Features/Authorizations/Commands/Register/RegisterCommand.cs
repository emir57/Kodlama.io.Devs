using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
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
            User user = new();
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

            _mapper.Map(request.UserForRegisterDto, user);
            user.Status = true;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            User addedUser = await _userRepository.AddAsync(user, cancellationToken);
            if (addedUser == null)
                throw new BusinessException("");

            addedUser.UserOperationClaims.Add(new UserOperationClaim { UserId = addedUser.Id, OperationClaimId = 1 });
            await _userRepository.UpdateAsync(addedUser);

            UserForLoginDto userForLoginDto = _mapper.Map<UserForLoginDto>(request.UserForRegisterDto);
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto };

            AccessToken accessToken = await _mediator.Send(loginCommand, cancellationToken);
            return accessToken;
        }
    }
}
