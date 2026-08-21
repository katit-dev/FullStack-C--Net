using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

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
    }
}