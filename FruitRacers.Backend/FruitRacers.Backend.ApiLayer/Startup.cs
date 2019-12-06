using FruitRacers.Backend.ApiLayer.DependencyInjection;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FruitRacers.Backend.ApiLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            typeof(Startup).Assembly
                .GetTypes()
                .Where(t => typeof(IServiceInstaller).IsAssignableFrom(t))
                .Where(t => !(t.IsAbstract || t.IsInterface))
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>()
                .ForEach(installer => installer.InstallServices(services, this.Configuration));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Fruitracers API");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
