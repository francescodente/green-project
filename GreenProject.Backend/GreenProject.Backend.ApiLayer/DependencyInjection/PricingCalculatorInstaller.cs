using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Infrastructure.Pricing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class PricingCalculatorInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IPriceCalculator, DefaultPriceCalculator>();
        }
    }
}
