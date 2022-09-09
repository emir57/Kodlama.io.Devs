using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.devs.Application.Features.Authorizations.Constants;
using Kodlama.io.devs.Application.Services.Repositories;

namespace Kodlama.io.devs.Application.Features.Authorizations.Rules;

public sealed class AuthorizationBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthorizationBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserShouldExistsWhenLogin(string userEmail)
    {
        User? user = await _userRepository.GetAsync(u => u.Email.ToLower() == userEmail.ToLower());
        if (user == null)
            throw new BusinessException(AuthorizationMessages.UserNotFound);
    }
    public async Task UserShouldNotExistsWhenRegister(string userEmail)
    {
        User? user = await _userRepository.GetAsync(u => u.Email.ToLower() == userEmail.ToLower());
        if (user != null)
            throw new BusinessException(AuthorizationMessages.UserAlreadyExists);
    }

    public void VerifyPassword(UserForLoginDto userForLoginDto, User user)
    {
        if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt) == false)
            throw new BusinessException(AuthorizationMessages.WrongPassword);
    }
}
