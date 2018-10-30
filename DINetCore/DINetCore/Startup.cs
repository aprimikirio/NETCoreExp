using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using DINetCore.Services;

namespace DINetCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TimeService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TimeService timeService)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
            });
        }
    }
}
