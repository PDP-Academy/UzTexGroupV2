using UzTexGroupV2.Application.EntitiesDto;

namespace UzTexGroupV2.Application.Services
{
    public interface IServiceBase<TEntryCreate,TReturn, TEntryModify>
        where TEntryCreate : class 
        where TReturn : class
        where TEntryModify : class
    {
        ValueTask<TReturn> CreateEntityAsync(TEntryCreate entity);
        ValueTask<TReturn> DeleteEntityAsync(Guid Id);
        ValueTask<TReturn> ModifyEntityAsync(TEntryModify entity);
        ValueTask<IQueryable<TReturn>> RetrieveAllEntitiesAsync();
        ValueTask<TReturn> RetrieveByIdEntityAsync(Guid Id);
    }
}