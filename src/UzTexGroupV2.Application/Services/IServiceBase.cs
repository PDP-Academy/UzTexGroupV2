namespace UzTexGroupV2.Application.Services;

public interface IServiceBase
{
    ValueTask<TReturn> CreateEntityAsync<TEntry, TReturn>(TEntry entity);
    ValueTask<TReturn> RetrieveByIdEntityAsync<Guid, TReturn>(Guid Id);
    ValueTask<IQueryable<TReturn>> RetrieveAllEntitiesAsync<TReturn>();
    ValueTask<TReturn> ModifyEntityAsync<TEntry, TReturn>(TEntry entity);
    ValueTask<TReturn> DeleteEntityAsync<Guid, TReturn>(Guid Id);
}
