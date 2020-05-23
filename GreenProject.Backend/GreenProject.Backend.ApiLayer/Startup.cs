using GreenProject.Backend.ApiLayer.DependencyInjection;
using GreenProject.Backend.DataAccess.Sql;
using GreenProject.Backend.Shared.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.ApiLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ReflectionUtils.InstancesOfSubtypes<IServiceInstaller>(typeof(Startup).Assembly)
                .ForEach(installer => installer.InstallServices(services, this.Configuration, this.Environment));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction())
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = HttpOnlyPolicy.None,
                Secure = CookieSecurePolicy.SameAsRequest,
                MinimumSameSitePolicy = SameSiteMode.None
            });

            GlobalSettings settings = this.Configuration.GetSection(nameof(GlobalSettings)).Get<GlobalSettings>();
            app.UseCors(x => x
                .SetIsOriginAllowed(settings.AllowedOrigins.Contains)
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "GreenProject API");
            });

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
