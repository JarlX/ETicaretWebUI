using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ETicaretWebUI.UI.Middleware
{
    using ETicaretWEBUI.Helper.SessionHelper;

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Path.Value.Contains("/Admin/"))
            {
                if (SessionManager.LoggedUser == null)
                {
                    httpContext.Response.Redirect("/AdminAccount/Login");
                    httpContext.Response.WriteAsync("Yetkisiz Giriş");
                }
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SessionCheckMiddlewareExtensions
    {
        public static IApplicationBuilder SessionCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionCheckMiddleware>();
        }
    }
}

