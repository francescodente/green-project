﻿using FluentValidation.AspNetCore;
using FruitRacers.Backend.ApiLayer.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class ControllersInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services
                .AddControllers(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidationFilter>();
                    options.Filters.Add<DomainExceptionFilter>();
                })
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                    options.ImplicitlyValidateChildProperties = true;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
        }
    }
}