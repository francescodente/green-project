using GreenProject.Backend.ApiLayer.Utils.Csv;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class CsvInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICsvFactory, CsvFactory>();
        }
    }
}
