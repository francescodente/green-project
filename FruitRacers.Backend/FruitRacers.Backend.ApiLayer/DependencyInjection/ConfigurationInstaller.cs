using FruitRacers.Backend.ApiLayer.Validation.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class ConfigurationInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            this.InstallConfiguration<PasswordValidationSettings>(services, config, nameof(PasswordValidationSettings));
        }

        private void InstallConfiguration<T>(IServiceCollection services, IConfiguration config)
            where T : class
        {
            InstallConfiguration<T>(services, config, typeof(T).Name);
        }

        private void InstallConfiguration<T>(IServiceCollection services, IConfiguration config, string sectionName)
            where T : class
        {
            IConfiguration section = config.GetSection(sectionName);
            services.Configure<T>(section);
        }
    }
}
