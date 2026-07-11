using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend_netcore_dotnet06.Filters
{
    public class BlockIpAddressFilter : ActionFilterAttribute
    {
        public string IpAddress { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"BlockIpAddressFilter executing");

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
            Console.WriteLine($"BlockIpAddressFilter executed");
        }
    }
}