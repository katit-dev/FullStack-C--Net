using System;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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
            
            await next(context);
        }


        
    }
}
