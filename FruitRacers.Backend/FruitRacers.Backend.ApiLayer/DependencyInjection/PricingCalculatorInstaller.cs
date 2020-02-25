using FruitRacers.Backend.Core.Utils.Pricing;
using FruitRacers.Backend.Infrastructure.Pricing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class PricingCalculatorInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IPriceCalculator, DefaultPriceCalculator>();
        }
    }
}
