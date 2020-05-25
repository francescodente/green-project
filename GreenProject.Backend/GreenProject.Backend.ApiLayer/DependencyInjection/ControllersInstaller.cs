using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Internal;
using GreenProject.Backend.ApiLayer.Converter;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class ControllersInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IValidatorInterceptor, ValidationResultInterceptor>();
            services
                .AddControllers(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidationFilter>();
                    options.Filters.Add<DomainExceptionFilter>();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddFluentValidation(options =>
                {
                    ValidatorOptions.PropertyNameResolver = (type, memberInfo, expr) =>
                        PropertyNameResolvers.CamelCase(memberInfo, expr);
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                    options.ImplicitlyValidateChildProperties = true;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.Converters.Add(new MoneyConverter());
                    options.SerializerSettings.FloatParseHandling = FloatParseHandling.Decimal;
                });
        }
    }
}
