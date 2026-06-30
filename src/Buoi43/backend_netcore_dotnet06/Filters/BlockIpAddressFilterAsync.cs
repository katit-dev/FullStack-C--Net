using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using backend_netcore_dotnet06.Models.DBUser;



public class BlockIpAddressFilterAsync : ActionFilterAttribute
{

    public string IpAddress { get; set; }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        //ứng với action filter executing, 
        Console.WriteLine($@"BlockIpAddressFilterAsync executing");
        var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (ipAddress == IpAddress)
        {
            context.Result = new ContentResult
            {
                StatusCode = 403, // Forbidden
                Content = "Access denied for this IP address."
            };
            return;
        }
        //action xử lý hoặc các filter khác sẽ được thực thi sau khi gọi await next();
        var contextResult = await next();

        //ứng với action filter executed

        Console.WriteLine($@"BlockIpAddressFilterAsync executed");
        contextResult.Result = new ContentResult
        {
            StatusCode = 403, // Forbidden
            Content = $"Access denied for this IP address."
        };
    }
}