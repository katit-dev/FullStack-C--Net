using backend_netcore_dotnet06.Filters;
using Microsoft.AspNetCore.Mvc;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoFilterController : ControllerBase
    {
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
    }
}