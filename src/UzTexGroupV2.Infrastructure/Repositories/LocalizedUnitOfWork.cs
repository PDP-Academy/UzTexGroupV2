using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class LocalizedUnitOfWork : UnitOfWorkBase
{
    public readonly NewsRepository NewsRepository;
    public readonly JobRepository JobRepository;
    public readonly CompanyRepository CompanyRepository;
    public readonly FactoryRepository FactoryRepository;
    public LocalizedUnitOfWork(UzTexGroupDbContext uzTexGroupDbContext) : base(uzTexGroupDbContext)
    {
        this.NewsRepository = new NewsRepository(this.uzTexGroupDbContext);
        this.JobRepository = new JobRepository(this.uzTexGroupDbContext);
        this.CompanyRepository = new CompanyRepository(this.uzTexGroupDbContext);
        this.FactoryRepository = new FactoryRepository(this.uzTexGroupDbContext);
    }

    public async ValueTask ChangeLocalization(Language? language)
    {
        if (language is null)
            language = new Language();
        var properties = this
            .GetType()
            .GetProperties();
        foreach (var property in properties)
        {
            if (property is null)
                continue;
            property?
               .GetType()?
               .GetProperty("language")?
               .SetValue(property.GetType(), language);
        }
    }
}