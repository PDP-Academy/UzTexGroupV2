using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class CompanyRepository : RepositoryBase<Company>
{
    public CompanyRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}