using FruitRacers.Backend.ApiLayer.Validation.Configuration;
using FruitRacers.Backend.Core.Utils.Uploads;
using FruitRacers.Backend.Infrastructure.Email;
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
            this.InstallConfiguration<PasswordValidationSettings>(services, config);
            this.InstallConfiguration<MailSettings>(services, config);
            this.InstallConfiguration<ImageUploadSettings>(services, config);
        }

        private void InstallConfiguration<T>(IServiceCollection services, IConfiguration config)
            where T : class
        {
            this.InstallConfiguration<T>(services, config, typeof(T).Name);
        }

        private void InstallConfiguration<T>(IServiceCollection services, IConfiguration config, string sectionName)
            where T : class
        {
            services.AddSingleton(config.GetSection(sectionName).Get<T>());
        }
    }
}
