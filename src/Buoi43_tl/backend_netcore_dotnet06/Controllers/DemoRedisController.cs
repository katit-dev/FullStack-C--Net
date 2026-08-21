using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoRedisController : ControllerBase
    {
        private readonly RedisService _redisService;
        private readonly UserDBContext _userDBContext;

        public DemoRedisController(
            RedisService redisService,
            UserDBContext userDBContext)
        {
            redisService.indexDB = 0;
            _redisService = redisService;
            _userDBContext = userDBContext;
        }



        [HttpGet("GetAllUserRedis")]
        public async Task<IActionResult> GetAllUserRedis()
        {
            // Kiểm tra key "all_users" có trong Redis không
            var cachedUsers = await _redisService
                .GetValueAsync("all_users");

            // Nếu Redis có dữ liệu
            if (!string.IsNullOrEmpty(cachedUsers))
            {
                var users = JsonSerializer
                    .Deserialize<List<User>>(cachedUsers);

                return Ok(users);
            }

            // Nếu Redis không có -> lấy từ Database
            var usersFromDb = await _userDBContext
                .Users
                .ToListAsync();

            // Serialize List<User> thành JSON string
            var jsonUsers = JsonSerializer
                .Serialize(usersFromDb);

            // Lưu JSON string vào Redis
            await _redisService
                .SetValueAsync(
                    "all_users",
                    jsonUsers
                );

            return Ok(usersFromDb);
        }
        

    }
}