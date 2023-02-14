using Microsoft.EntityFrameworkCore;
using Serilog;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.MIddlewares;

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

    public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        //DO-NOT: Unit Of works can't to add to services as Transient
        serviceCollection.AddScoped<LocalizedUnitOfWork>();
        serviceCollection.AddScoped<UnitOfWork>();

        return serviceCollection;
    }

    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<AddressService>();
        serviceCollection.AddScoped<ApplicationService>();
        serviceCollection.AddScoped<CompanyService>();
        serviceCollection.AddScoped<FactoryService>();
        serviceCollection.AddScoped<JobService>();
        serviceCollection.AddScoped<NewsService>();
        serviceCollection.AddScoped<UserService>();

        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        return serviceCollection;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<LocalizationTrackerMiddleware>();

        return serviceCollection;
    }

    public static WebApplicationBuilder AdSeridLogg(
           this WebApplicationBuilder builder,
           IConfiguration configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        return builder;
    }
}