using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class NewsRepository : RepositoryBase<News>
{
    public NewsRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}