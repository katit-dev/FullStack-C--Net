//api-controller-async
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Models.DBQuanLyNhanVien;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using backend_netcore_dotnet06.Models.DBUser;
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoCacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly UserDBContext _conte;
        public DemoCacheController(IMemoryCache memoryCache, UserDBContext context)
        {
            _memoryCache = memoryCache;
            _conte = context;
        }


        [HttpGet("GetAllUserCache")]
        public async Task<ActionResult> GetAllUserCache()
        {
            //Đặt key cho cache
            string cacheKey = "all_users";
            Console.WriteLine($@"Vào action");

            //Kiểm tra xem dữ liệu đã có trong cache chưa
            if (!_memoryCache.TryGetValue(cacheKey, out List<User> users))
            {

                //Nếu chưa có trong cache, truy vấn dữ liệu từ cơ sở dữ liệu
                users = await _conte.Users.ToListAsync();

                // //Đặt thời gian hết hạn cho cache (ví dụ: 5 phút)
                // var cacheEntryOptions = new MemoryCacheEntryOptions()
                //     .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                Console.WriteLine($@"Chưa cache cache lần 1");

                //Lưu dữ liệu vào cache
                _memoryCache.Set(cacheKey, users);
            }

            return Ok(users);
        }

        [HttpPost("AddUserCache")]
        public async Task<ActionResult> AddUserCache([FromBody] User newUser)
        {
            //Thêm người dùng mới vào cơ sở dữ liệu
            _conte.Users.Add(newUser);
            await _conte.SaveChangesAsync();

            //Cập nhật cache sau khi thêm người dùng mới
            string cacheKey = "all_users";
            var users = await _conte.Users.ToListAsync();
            _memoryCache.Set(cacheKey, users);

            return CreatedAtAction(nameof(GetAllUserCache), new { id = newUser.Id }, newUser);
        }


        [HttpDelete("ClearCache")]
        public IActionResult ClearCache()
        {
            string cacheKey = "all_users";
            _memoryCache.Remove(cacheKey);
            return NoContent();
        }
        [HttpGet("CheckRamCapacityCache")]
        public IActionResult CheckRamCapacityCache()
        {
            //Kiểm tra dung lượng RAM hiện tại
            //Tính toán phần trăm dung lượng RAM đã sử dụng đổi sang MB
            var totalMemory = GC.GetTotalMemory(false) / (1024 * 1024); // Tổng dung lượng RAM đã sử dụng (MB)
            var maxMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes / (1024 * 1024); // Dung lượng RAM tối đa (MB)
            var usedMemoryPercentage = (double)totalMemory / maxMemory * 100; // Phần trăm dung lượng RAM đã sử dụng
            return Ok(new { TotalMemoryMB = totalMemory, MaxMemoryMB = maxMemory, UsedMemoryPercentage = usedMemoryPercentage });
        }


        //Output cache dùng để cache kết quả của api
        [HttpGet("GetAllUserOutputCache")]
        [ResponseCache(Duration = 60)] // Cache kết quả trong 60 giây
        public async Task<ActionResult> GetAllUserOutputCache()
        {
            Console.WriteLine($@"Vào action GetAllUserOutputCache");
            var users = await _conte.Users.ToListAsync();
            return Ok(users);
        }



    }
}