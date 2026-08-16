using backend_netcore_dotnet06.Filters;
using Microsoft.AspNetCore.Mvc;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoFilterController : ControllerBase
    {
        // 1. Khai báo logger
        private readonly ILogger<DemoFilterController> _logger;

        // 2. Nhận logger từ DI
        public DemoFilterController(ILogger<DemoFilterController> logger)
        {
            _logger = logger;
        }
        [HttpGet("TestFilterName")]
        [BlockIpAddressFilter(IpAddress = "199.111.122.133")]
        public ActionResult TestFilterBlockIpAddress([FromQuery] string model)
        {
            Console.WriteLine($"Action handler");

            var res = new
            {
                Message = "Bạn đã đi qua filter BlockIpAddress thành công!"
            };

            return Ok(res);
        }

        [HttpGet("TestFilterNameAsync")]
        [BlockIpAddressFilterAsync(IpAddress = "199.111.122.133")]
        public async Task<ActionResult> TestFilterBlockIpAddressAsync([FromQuery] string model)
        {
            Console.WriteLine($"Action handler");

            var res = new
            {
                Message = "Bạn đã đi qua filter BlockIpAddressAsync thành công!"
            };

            // log ket qua
            _logger.LogInformation(
            "User gọi API Demo/Get lúc {Time}",
            DateTime.Now
        );

            return Ok(res);
        }
    }
}