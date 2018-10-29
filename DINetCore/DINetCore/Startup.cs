﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace DINetCore
{
    public class Startup
    {
        private IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>All services</h1>");
                sb.Append("<table>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Realization</th></tr>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            });
        }
    }
}
