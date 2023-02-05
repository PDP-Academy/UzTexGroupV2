using UzTexGroupV2.Application.EntitiesDto;

namespace UzTexGroupV2.Application.Services
{
    public interface IServiceBase
    {
        ValueTask<UserDto> CreateEntityAsync<TEntry, TReturn>(CreateUserDto createUserDto);
        ValueTask<TReturn> DeleteEntityAsync<Guid, TReturn>(Guid Id);
        ValueTask<TReturn> ModifyEntityAsync<TEntry, TReturn>(TEntry entity);
        ValueTask<IQueryable<TReturn>> RetrieveAllEntitiesAsync<TReturn>();
        ValueTask<TReturn> RetrieveByIdEntityAsync<Guid, TReturn>(Guid Id);
    }
}