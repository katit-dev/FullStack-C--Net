using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;



public class BlockIpAddressFilter : ActionFilterAttribute
{

    public string IpAddress { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($@"BlockIpAddressFilter executing");
        var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (ipAddress == IpAddress)
        {
            context.Result = new ContentResult
            {
                StatusCode = 403, // Forbidden
                Content = "Access denied for this IP address."
            };
        }
        
    }


    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($@"BlockIpAddressFilter executed");

        // viết lại body response để trả về thông tin ip của client và user agent
        // var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
        // var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();       
        //     context.Result = new ContentResult
        //     {
        //         StatusCode = 403, // Forbidden
        //         Content = $"Access denied for this IP address. IP: {ipAddress}, User-Agent: {userAgent}"
        //     };

        context.Result = new ContentResult
        {
            StatusCode = 403, // Forbidden
            Content = $"Access denied for this IP address."
        };
    }

}