using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Authentication;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class UserService
{
    private readonly IPasswordHasher passwordHasher;
    private readonly UnitOfWork unitOfWork;

    public UserService(UnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        this.unitOfWork = unitOfWork;
        this.passwordHasher = passwordHasher;
    }

    public async ValueTask<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = UserMap.MapToUser(
            createUserDto,
            passwordHasher);

        var storedUser = await unitOfWork
            .UserRepository
            .CreateAsync(user);

        await unitOfWork
            .SaveChangesAsync();

        return UserMap.MapToUserDto(storedUser);
    }

    public async ValueTask<UserDto> DeleteUserAsync(Guid Id)
    {
        var storedUser = await GetByExpressionAsync(Id);

        var deletedUser = await this.unitOfWork
            .UserRepository
            .DeleteAsync(storedUser);
        
        await this.unitOfWork.SaveChangesAsync();

        return UserMap.MapToUserDto(deletedUser);
    }

    public async ValueTask<UserDto> ModifyUserAsync(ModifyUserDto modifyUserDto)
    {
        var storedUser = await GetByExpressionAsync(modifyUserDto.id);

        UserMap.MapToUser(modifyUserDto, storedUser);

        var modifiedUser = await this.unitOfWork
            .UserRepository
            .UpdateAsync(storedUser);

        await this.unitOfWork.SaveChangesAsync();

        return UserMap.MapToUserDto(modifiedUser);
    }

    public async ValueTask<IQueryable<UserDto>> RetrieveAllUsersAsync()
    {
        var users = await this.unitOfWork
            .UserRepository
            .GetAllAsync();

        return users.Select(user => UserMap.MapToUserDto(user));
    }

    public async ValueTask<UserDto> RetrieveByIdUserAsync(Guid Id)
    {
        var storedUser = await GetByExpressionAsync(Id);

        return UserMap.MapToUserDto(storedUser);
    }
    private async ValueTask<User> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var users = await this.unitOfWork.UserRepository
           .GetByExpression(expression => expression.Id == id, new string[] { });

        var user = await users.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable(user);

        return user;

    }

    /*private async Task ValidateEmailForRequired(User user)
    {
        var users = await this.unitOfWork.UserRepository
            .GetByExpression(expression => expression.Email == user.Email)
    }*/
}
