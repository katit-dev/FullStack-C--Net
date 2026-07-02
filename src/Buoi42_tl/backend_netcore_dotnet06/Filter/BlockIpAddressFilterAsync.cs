using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend_netcore_dotnet06.Filters
{
    public class BlockIpAddressFilterAsync : ActionFilterAttribute
    {
        public string IpAddress { get; set; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"BlockIpAddressFilterAsync executing");

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

            // truoc await next(); la OnActionExecuting
            var contextResult = await next();
            // neu co cac filter khac, thi cac filter khac se duoc thuc hien truoc khi vao OnActionExecuted cua filter nay
            // de lay contextResult.Result de lay ket qua cua action handler

            // sau await next(); la OnActionExecuted
            Console.WriteLine($@"BlockIpAddressFilterAsync executed");
            contextResult.Result = new ContentResult
            {
                StatusCode = 403,
                Content = "Access denied for this IP address."
            };
        }
    }
}