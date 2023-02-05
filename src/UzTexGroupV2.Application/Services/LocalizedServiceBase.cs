using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public abstract class LocalizedServiceBase : IServiceBase
{
    private readonly LocalizedUnitOfWork unitOfWork;

    public LocalizedServiceBase(LocalizedUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public abstract ValueTask<TReturn> CreateEntityAsync<TEntry, TReturn>(TEntry entity);

    public abstract ValueTask<TReturn> DeleteEntityAsync<Guid, TReturn>(Guid Id);

    public abstract ValueTask<TReturn> ModifyEntityAsync<TEntry, TReturn>(TEntry entity);
    public abstract ValueTask<IQueryable<TReturn>> RetrieveAllEntitiesAsync<TReturn>();
    public abstract ValueTask<TReturn> RetrieveByIdEntityAsync<Guid, TReturn>(Guid Id);
}
