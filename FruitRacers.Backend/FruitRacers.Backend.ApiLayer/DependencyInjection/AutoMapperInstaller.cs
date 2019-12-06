using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Services.Utils;
using Microsoft.Extensions.Configuration;

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
