using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Infrastructure.Pricing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class PricingCalculatorInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddSingleton<IPricingService, DefaultPriceCalculator>();
        }
    }
}
