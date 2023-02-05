using System.Linq.Expressions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class 
{
    private readonly UzTexGroupDbContext context;
    public RepositoryBase(UzTexGroupDbContext context)
    {
        this.context = context;
    }


    public virtual async ValueTask<IQueryable<T>> GetAllAsync()
    {
        return context
            .Set<T>();
    }

    public virtual async ValueTask<IQueryable<T>> GetByExpression(Expression<Func<T, bool>> expression)
    {
        return context
            .Set<T>()
            .Where(expression);
    }

    public async ValueTask<T> CreateAsync(T entity)
    {
        return (await context
                .Set<T>()
                .AddAsync(entity))
            .Entity;

    }

    public async ValueTask<T> UpdateAsync(T entity)
    {
        return context
            .Set<T>()
            .Update(entity)
            .Entity;
    }

    public async ValueTask<T> DeleteAsync(T entity)
    {
        return context
            .Set<T>()
            .Remove(entity)
            .Entity;
    }
}