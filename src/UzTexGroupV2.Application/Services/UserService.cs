using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class UserService : IServiceBase
{
    private readonly UnitOfWork unitOfWork;

    public UserService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<UserDto> CreateEntityAsync<TEntry, TReturn>(CreateUserDto createUserDto)
    {
        var user = UserMap.MapToUser(createUserDto);
        var storedUser = await unitOfWork.UserRepository
            .CreateAsync(user);

        await unitOfWork
            .SaveChangesAsync();

        return UserMap.MapToUserDto(user);
    }

    public override ValueTask<TReturn> DeleteEntityAsync<Guid, TReturn>(Guid Id)
    {

    }

    public override ValueTask<TReturn> ModifyEntityAsync<TEntry, TReturn>(TEntry entity)
    {

    }

    public override ValueTask<IQueryable<TReturn>> RetrieveAllEntitiesAsync<TReturn>()
    {

    }

    public override ValueTask<TReturn> RetrieveByIdEntityAsync<Guid, TReturn>(Guid Id)
    {
        throw new NotImplementedException();
    }
}
