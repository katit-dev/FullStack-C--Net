using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace backend_netcore_dotnet06.Middleware
{
    

    // REMEMBER: Add `services.AddTransient<NameMiddleware>();` to Startup.ConfigureServices() method
    public class NameMiddleware : IMiddleware
    {
        // IMiddleware is activated per request, 
        // so scoped services can be injected into the middleware's constructor.
        public NameMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var hostNameClient = context.Request.Host.Host;
            // .host.host: host 1st la domain, host 2nd la subdomain
            //
            Console.WriteLine($@"Ten mien client: {hostNameClient}");
            await next(context);
        }
    }
}
