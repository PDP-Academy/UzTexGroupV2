using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Domain.Enums;

namespace UzTexGroupV2.Application.MappingProfiles;

public static class UserMap
{
    public static User MapToUser(CreateUserDto createUserDto)
    {
        return new User
        {
            Id = createUserDto.id ?? Guid.NewGuid(),
            FirstName = createUserDto.firstName,
            LastName = createUserDto.lastName,
            Email = createUserDto.email,
            UserRole = Role.User,
            PasswordHash = createUserDto.password
        };
    }
    public static UserDto MapToUserDto(User user) =>
        new UserDto(user.Id, user.FirstName, user.LastName, user.Email, user.UserRole);

    public static void MapToUser(ModifyUserDto modifyUserDto, User user)
    {
        user.FirstName = modifyUserDto.firstName ?? user.FirstName;
        user.LastName = modifyUserDto.lastName ?? user.LastName;
        user.Email = modifyUserDto.email ?? user.Email;
    }
}
