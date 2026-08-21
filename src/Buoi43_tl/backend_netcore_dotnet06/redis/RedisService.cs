using StackExchange.Redis;

public class RedisService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public int indexDB { get; set; } = 0;

    public int expiresInSeconds { get; set; } = 3600; 
    // default 1 hour


    public RedisService(
        IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }


    // SET value vào Redis + thời gian hết hạn
    public async Task SetValueAsync(
        string key,
        string value)
    {
        var db = _connectionMultiplexer
            .GetDatabase(indexDB);

        await db.StringSetAsync(
            key,
            value,
            TimeSpan.FromSeconds(expiresInSeconds)
        );
    }


    // GET value từ Redis
    public async Task<string?> GetValueAsync(
        string key)
    {
        var db = _connectionMultiplexer
            .GetDatabase(indexDB);

        return await db.StringGetAsync(key);
    }


    // REMOVE key khỏi Redis
    public async Task<bool> RemoveKeyAsync(
        string key)
    {
        var db = _connectionMultiplexer
            .GetDatabase(indexDB);

        return await db.KeyDeleteAsync(key);
    }
}