using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FruitRacers.Backend.Infrastructure.Mapping;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(MappingUtils.CreateDefaultMapper());
        }
    }
}
