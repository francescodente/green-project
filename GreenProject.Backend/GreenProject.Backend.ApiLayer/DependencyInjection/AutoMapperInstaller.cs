using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GreenProject.Backend.Infrastructure.Mapping;
using Microsoft.AspNetCore.Hosting;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddSingleton(MappingUtils.CreateDefaultMapper());
        }
    }
}
