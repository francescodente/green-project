using FruitRacers.Backend.Core.Utils.Uploads;
using FruitRacers.Backend.Infrastructure.Uploads;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class ImageStorageInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(provider => this.CreateImageStorage(provider, config));
        }

        private IImageStorage CreateImageStorage(IServiceProvider provider, IConfiguration config)
        {
            string basePath = provider.GetRequiredService<IWebHostEnvironment>().WebRootPath;
            ImageUploadSettings settings = provider.GetRequiredService<ImageUploadSettings>();
            return new LocalImageStorage(basePath, settings.DefaultFormat.GetExtension());
        }
    }
}
