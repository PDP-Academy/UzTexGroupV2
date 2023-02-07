using System.Linq.Expressions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class LocalizedRepositoryBase<T> : RepositoryBase<T> where T : LocalizedObject
{
    public Language Language { get; set; }
    public LocalizedRepositoryBase(UzTexGroupDbContext context) : base(context)
    {
    }
    public override async ValueTask<IQueryable<T>> GetAllAsync()
    {
        return (await base.GetAllAsync())
            .Where(entity => entity.LanguageCode == Language.Code);
    }

    public override async ValueTask<IQueryable<T>> GetByExpression(Expression<Func<T, bool>> expression)
    {
        return (await base
                .GetByExpression(expression))
            .Where(entity => entity.LanguageCode == Language.Code);
    }
}