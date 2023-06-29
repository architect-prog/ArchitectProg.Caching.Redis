namespace ArchitectProg.Caching.Redis.Settings;

public sealed class CacheSettings
{
    public string ConnectionString { get; set; } = null!;
    public string InstanceName { get; set; } = null!;
    public long DefaultExpirationTime { get; set; }
}