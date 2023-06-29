using ArchitectProg.Caching.Redis.Services.Interfaces;
using ArchitectProg.Caching.Redis.Settings;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace ArchitectProg.Caching.Redis.Services;

public sealed class CacheStoreProvider : ICacheStoreProvider
{
    private readonly CacheSettings cacheSettings;
    private readonly IConnectionMultiplexer connection;

    private readonly Lazy<IDatabase> database;

    public IDatabase Database => database.Value;
    public TimeSpan DefaultExpirationTime => TimeSpan.FromSeconds(cacheSettings.DefaultExpirationTime);

    public CacheStoreProvider(IOptions<CacheSettings> cacheSettings)
    {
        this.cacheSettings = cacheSettings.Value;

        connection = ConnectionMultiplexer.Connect(this.cacheSettings.ConnectionString);
        database = new Lazy<IDatabase>(GetDatabase, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    private IDatabase GetDatabase()
    {
        var result = connection.GetDatabase();
        return result;
    }

    public void Dispose()
    {
        connection.Dispose();
    }
}