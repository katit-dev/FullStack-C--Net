using Microsoft.Extensions.Caching.Distributed;

public class RedisService
{
    private readonly IDistributedCache _cache;


    public int indexDB { get; set; } = 0;

    public int expiresInSeconds { get; set; } = 3600; 
    // default 1 hour


    public RedisService(IDistributedCache cache)
    {
        _cache = cache;
    }


    // SET value vào Redis
    public async Task SetValueAsync(
        string key,
        string value)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow =
                TimeSpan.FromSeconds(expiresInSeconds)
        };


        await _cache.SetStringAsync(
            key,
            value,
            options
        );
    }


    // GET value từ Redis
    public async Task<string?> GetValueAsync(
        string key)
    {
        return await _cache.GetStringAsync(key);
    }


    // REMOVE key
    public async Task<bool> RemoveKeyAsync(
        string key)
    {
        await _cache.RemoveAsync(key);

        return true;
    }
}