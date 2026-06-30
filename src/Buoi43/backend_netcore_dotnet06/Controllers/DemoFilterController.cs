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
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoFillterController : ControllerBase
    {
        private readonly ILogger<DemoFillterController> _logger;
        public DemoFillterController(ILogger<DemoFillterController> logger)
        {
            _logger = logger;
        }


        [HttpGet("TestFilterName")]
        [BlockIpAddressFilter(IpAddress = "199.111.122.133")]
        public ActionResult TestFilterBlockIpAddress([FromQuery] string model)
        {
            Console.WriteLine($@"Action handler");
            var res = new
            {
                Message = "Bạn đã đi qua filter BlockIpAddress thành công!"
            };
            //Log kết quả
            _logger.LogInformation(@$"User gọi API Demo/Get lúc {JsonSerializer.Serialize(res)}", DateTime.Now);



            return Ok(res);
        }


        [HttpGet("TestFilterNameAsync")]
        [BlockIpAddressFilterAsync(IpAddress = "199.111.122.133")]
        [ServiceFilter(typeof(LogFilter))] //Gắn filter LogFilter vào action
        public async Task<ActionResult> TestFilterBlockIpAddressAsync([FromQuery] string model)
        {
            Console.WriteLine($@"Action handler");


            var res = new
            {
                Message = "Bạn đã đi qua filter BlockIpAddress thành công!"
            };
            return Ok(res);
        }


        [HttpGet("TestExceptionFilter")]
        [ServiceFilter(typeof(ExceptionActionFilter))] //Gắn filter ExceptionActionFilter vào action
        public ActionResult TestExceptionFilter()
        {
            int a = 0;
            int b = 1 / a; // This will throw a DivideByZeroException   


            return Ok(b);
        }
    }
}