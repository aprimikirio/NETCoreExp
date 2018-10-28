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
            app.UseSession();
            app.Run(async (context) =>
            {
                if (context.Session.Keys.Contains("person"))
                {
                    Person person = context.Session.Get<Person>("person");
                    await context.Response.WriteAsync($"Hello {person.Name}!");
                }
                else
                {
                    Person person = new Person { Name = "Tom", Age = 22 };
                    context.Session.Set<Person>("person", person);
                    await context.Response.WriteAsync("Hello World!");
                }
            });
        }
    }
}