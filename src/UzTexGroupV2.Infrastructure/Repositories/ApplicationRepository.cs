using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class ApplicationRepository : RepositoryBase<Applications>
{
    public ApplicationRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}