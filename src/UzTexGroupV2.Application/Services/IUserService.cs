using UzTexGroupV2.Application.Entities.Users;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.Services;

public interface IUserService
{
    ValueTask<User> CreateUserAsync(CreateUserDto createUserDto);
    ValueTask<User> RetrieveByIdUserAsync(Guid UserId);
    ValueTask<User> ModifyUserAsync()
}
