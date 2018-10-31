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
            services.AddTransient<IMessageSender, EmailMessageSender>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                IMessageSender messageSender = context.RequestServices.GetService<IMessageSender>();
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(messageSender.Send());
            });
        }
    }
}
