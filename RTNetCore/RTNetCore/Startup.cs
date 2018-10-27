using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RTNetCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        { }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                context.Items["text"] = "Vsem zdarova, pacani!!!";
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
            });
        }
    }
}
