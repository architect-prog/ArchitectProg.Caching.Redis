using ArchitectProg.Caching.Redis.Services;
using ArchitectProg.Caching.Redis.Services.Interfaces;
using ArchitectProg.Kernel.Extensions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectProg.Caching.Redis;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisCache(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddScoped<ICacheService, CacheService>();
        serviceCollection.AddScoped<ICacheStoreProvider, CacheStoreProvider>();

        return serviceCollection;
    }
}