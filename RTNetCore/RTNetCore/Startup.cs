using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace RTNetCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseSession();

            app.Run(async (context) =>
            {
                if (context.Session.Keys.Contains("name"))
                    await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
                else
                {
                    context.Session.SetString("name", "Tom");
                    await context.Response.WriteAsync("Hello World!");
                }
            });
        }
    }
}
