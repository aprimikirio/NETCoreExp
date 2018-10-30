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
        private IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, SmsMessageSender>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageSender messageSender)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageSender.Send());
            });
        }
    }
}
