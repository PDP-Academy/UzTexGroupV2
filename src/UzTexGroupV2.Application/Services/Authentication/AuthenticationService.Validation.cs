using UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;
using UzTexGroupV2.Domain;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.Services;

public partial class AuthenticationService
{
    private void ValidateStorageUser(User user)
    {
        if (user == null)
            throw new NotFoundException("Email yoki password xato");
    }
    private void ValidateStoragePassword(User user, LoginDto loginDto)
    {
        if(!passwordHasher.VerifyPassword(
            password: loginDto.password,
            salt: user.Salt,
            hash: user.PasswordHash))
        {
            throw new NotFoundException("Email yoki password xato");
        }
    }
}
