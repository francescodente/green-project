using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.HostedServices;
using GreenProject.Backend.ApiLayer.Utils.Csv;
using GreenProject.Backend.ApiLayer.Validation.Configuration;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Uploads;
using GreenProject.Backend.Infrastructure.Notifications.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class ConfigurationInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            InstallConfiguration<PasswordValidationSettings>(services, config);
            InstallConfiguration<MailSettings>(services, config);
            InstallConfiguration<ImageUploadSettings>(services, config);
            InstallConfiguration<PricingSettings>(services, config);
            InstallConfiguration<NotificationsDaemonSettings>(services, config);
            InstallConfiguration<OrdersSettings>(services, config);
            InstallConfiguration<CsvSettings>(services, config);
            InstallConfiguration<CacheSettings>(services, config);
        }

        private void InstallConfiguration<T>(IServiceCollection services, IConfiguration config)
            where T : class
        {
            InstallConfiguration<T>(services, config, typeof(T).Name);
        }

        private void InstallConfiguration<T>(IServiceCollection services, IConfiguration config, string sectionName)
            where T : class
        {
            services.AddSingleton(config.GetSection(sectionName).Get<T>());
        }
    }
}
