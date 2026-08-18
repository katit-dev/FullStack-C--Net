using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoCacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly UserDBContext _context;

        public DemoCacheController(
            IMemoryCache memoryCache,
            UserDBContext context)
        {
            _memoryCache = memoryCache;
            _context = context;
        }

        [HttpGet("GetAllUserCache")]
        public async Task<ActionResult> GetAllUserCache()
        {
            // Đặt key cho cache
            string cacheKey = "all_users";

            Console.WriteLine("Vào action");

            // Kiểm tra xem dữ liệu đã có trong cache chưa
            if (!_memoryCache.TryGetValue(cacheKey, out List<User> users))
            {
                // Nếu chưa có trong cache, truy vấn dữ liệu từ cơ sở dữ liệu
                users = await _context.Users.ToListAsync();

                // Đặt thời gian hết hạn cho cache (ví dụ: 5 phút)
                // var cacheEntryOptions = new MemoryCacheEntryOptions()
                //     .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                Console.WriteLine("Chưa cache cache lần 1");

                // Lưu dữ liệu vào cache
                _memoryCache.Set(cacheKey, users);
            }

            return Ok(users);
        }

        // api them user moi va db roi cap nhat lai cache all_users de cache khong bi du lieu cu
        [HttpPost("AddUserCache")]
        public async Task<ActionResult> AddUserCache([FromBody] User newUser)
        {
            // Thêm người dùng mới vào cơ sở dữ liệu
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Cập nhật cache sau khi thêm người dùng mới
            string cacheKey = "all_users";

            var users = await _context.Users.ToListAsync();

            _memoryCache.Set(cacheKey, users);

            return CreatedAtAction(
                nameof(GetAllUserCache),
                new { id = newUser.Id },
                newUser
            );
        }

        [HttpDelete("ClearCache")]
        public IActionResult ClearCache()
        {
            string cacheKey = "all_users";

            _memoryCache.Remove(cacheKey);

            return NoContent();
        }

        // Response cache dùng để cache kết quả response của API
        [HttpGet("GetAllUserOutputCache")]
        [ResponseCache(Duration = 60)] // Cache kết quả trong 60 giây
        public async Task<ActionResult> GetAllUserOutputCache()
        {
            Console.WriteLine("Vào action GetAllUserOutputCache");

            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }
    }
}