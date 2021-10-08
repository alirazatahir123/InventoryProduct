using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcelotGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            Configuration = configuration;

            builder.SetBasePath(env.ContentRootPath)
                  .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables();

            OcelotConfiguration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IConfiguration OcelotConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins()
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()
               )
            );
            services.AddControllers();
            services.AddOcelot(OcelotConfiguration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOcelot().Wait();
        }
    }
}
