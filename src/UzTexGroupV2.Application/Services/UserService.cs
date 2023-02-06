using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class UserService
{
    private readonly UnitOfWork unitOfWork;

    public UserService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<UserDto> CreateUserAsync<TEntry, TReturn>(CreateUserDto createUserDto)
    {
        var user = UserMap.MapToUser(createUserDto);
        var storedUser = await unitOfWork
            .UserRepository.CreateAsync(user);

        await unitOfWork
            .SaveChangesAsync();

        return UserMap.MapToUserDto(user);
    }

    public async ValueTask<UserDto> DeleteUserAsync(Guid Id)
    {
        var users = await this.unitOfWork
            .UserRepository
            .GetByExpression(expression: user =>
            user.Id == Id);

        var storedUser = await users.FirstOrDefaultAsync();

        var deletedUser = await this.unitOfWork
            .UserRepository.DeleteAsync(storedUser);

        return UserMap.MapToUserDto(deletedUser);
    }

    public async ValueTask<UserDto> ModifyUserAsync(ModifyUserDto modifyUserDto)
    {
        var users = await this.unitOfWork
            .UserRepository
            .GetByExpression(expression: user =>
            user.Id == modifyUserDto.id);

        var user = await users.FirstOrDefaultAsync();

        UserMap.MapToUser(modifyUserDto, user);

        var modifiedUser = await this.unitOfWork
            .UserRepository.UpdateAsync(user);

        await this.unitOfWork.SaveChangesAsync();

        return UserMap.MapToUserDto(user);
    }

    public async ValueTask<IQueryable<UserDto>> RetrieveAllUsersAsync()
    {
        var users = await this.unitOfWork
            .UserRepository.GetAllAsync();

        return users.Select(user => UserMap.MapToUserDto(user));
    }

    public async ValueTask<UserDto> RetrieveByIdEntityAsync(Guid Id)
    {
        var users = await this.unitOfWork
            .UserRepository
            .GetByExpression(expression: user =>
            user.Id == Id);

        var storedUser = await users.FirstOrDefaultAsync();

        return UserMap.MapToUserDto(storedUser);
    }
}
