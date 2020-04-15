using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Internal;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class ControllersInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
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
                    ValidatorOptions.PropertyNameResolver = PropertyNameResolvers.CamelCase;
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
