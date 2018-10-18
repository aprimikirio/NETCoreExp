using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RTNetCore
{
    public class Startup
    {
        IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<!DOCTYPE html><html><head><title>Test</title></html>");
            });
        }
    }
}
