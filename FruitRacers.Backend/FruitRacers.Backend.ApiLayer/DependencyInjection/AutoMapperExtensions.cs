using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Services.Utils;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddDtoMappers(this IServiceCollection services)
        {
            return services.AddSingleton(MappingUtils.CreateDefaultMapper());
        }
    }
}
