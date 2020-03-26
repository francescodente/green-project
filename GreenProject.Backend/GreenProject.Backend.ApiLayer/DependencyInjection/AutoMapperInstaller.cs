using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GreenProject.Backend.Infrastructure.Mapping;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(MappingUtils.CreateDefaultMapper());
        }
    }
}
