using GreenProject.Backend.ApiLayer.HostedServices;
using GreenProject.Backend.ApiLayer.Utils.Csv;
using GreenProject.Backend.ApiLayer.Validation.Configuration;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Uploads;
using GreenProject.Backend.Infrastructure.Email;
using GreenProject.Backend.Infrastructure.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class ConfigurationInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            this.InstallConfiguration<PasswordValidationSettings>(services, config);
            this.InstallConfiguration<MailSettings>(services, config);
            this.InstallConfiguration<ImageUploadSettings>(services, config);
            this.InstallConfiguration<MailNotificationsSettings>(services, config);
            this.InstallConfiguration<PricingSettings>(services, config);
            this.InstallConfiguration<NotificationsDaemonSettings>(services, config);
            this.InstallConfiguration<OrdersSettings>(services, config);
            this.InstallConfiguration<CsvSettings>(services, config);
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
