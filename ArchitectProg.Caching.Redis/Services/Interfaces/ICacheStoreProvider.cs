using StackExchange.Redis;

namespace ArchitectProg.Caching.Redis.Services.Interfaces;

public interface ICacheStoreProvider : IDisposable
{
    IDatabase Database { get; }
    TimeSpan DefaultExpirationTime { get; }
}