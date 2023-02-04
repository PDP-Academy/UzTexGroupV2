using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContexts(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<UzTexGroupDbContext>(obj =>
        {
            obj.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                obj => obj.EnableRetryOnFailure());
        }); 

        return services;
    }
}
