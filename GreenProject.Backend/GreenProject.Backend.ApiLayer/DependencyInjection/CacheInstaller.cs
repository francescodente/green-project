using GreenProject.Backend.Core.Utils.Caching;
using GreenProject.Backend.Infrastructure.Caching;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class CacheInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddMemoryCache(options =>
            {
                options.SizeLimit = 50;
            });

            services.AddScoped<ICacheService, InMemoryCache>();
        }
    }
}
