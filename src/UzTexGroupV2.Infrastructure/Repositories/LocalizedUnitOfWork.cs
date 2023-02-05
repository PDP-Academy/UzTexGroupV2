using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class LocalizedUnitOfWork
{
    public UserRepository UserRepository { get; private set; }

    public LocalizedUnitOfWork(UzTexGroupDbContext uzTexGroupDbContext)
    {
        this.UserRepository = new UserRepository(uzTexGroupDbContext);
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