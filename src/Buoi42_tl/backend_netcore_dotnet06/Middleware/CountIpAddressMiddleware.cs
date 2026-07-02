using System;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend_netcore_dotnet06.Middleware
{
    public class CountIpAddressMiddleware : IMiddleware
    {
        private readonly UserDBContext __userDBcontext;

        // IMiddleware is activated per request, 
        // so scoped services can be injected into the middleware's constructor.
        public CountIpAddressMiddleware(UserDBContext userDBcontext)
        {
            __userDBcontext = userDBcontext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            // 
            if (!string.IsNullOrEmpty(ipAddress))
            {
                // neu lay duoc ipAddress roi
                // kiem tra ip do trong db
                IpCount? ipRequest = await __userDBcontext.IpCounts.SingleOrDefaultAsync(ip => ip.Ip == ipAddress && ip.DateRequest == DateTime.Today);
                // neu chua co thi tao moi
                if (ipRequest == null)
                {
                    ipRequest = new IpCount
                    {
                        Ip = ipAddress,
                        Count = 1,
                        DateRequest = DateTime.Today
                    };
                    __userDBcontext.IpCounts.Add(ipRequest);
                }
                else
                {
                    // neu co roi thi tang count len 1
                    ipRequest.Count++;
                }
                await __userDBcontext.SaveChangesAsync();
            }
            await next(context);
        }



    }
}
