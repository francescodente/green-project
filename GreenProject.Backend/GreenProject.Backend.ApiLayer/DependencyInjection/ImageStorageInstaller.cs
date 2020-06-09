using GreenProject.Backend.Core.Utils.Uploads;
using GreenProject.Backend.Infrastructure.Uploads;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class ImageStorageInstaller : IServiceInstaller
    {
        private const string SubDirectory = "images";

        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddScoped(provider => CreateImageStorage(provider, env));
        }

        private IImageStorage CreateImageStorage(IServiceProvider provider, IWebHostEnvironment env)
        {
            ImageUploadSettings settings = provider.GetRequiredService<ImageUploadSettings>();
            string basePath = Path.Combine(settings.BaseFolder ?? env.WebRootPath, SubDirectory);
            return new LocalImageStorage(basePath, settings.DefaultFormat.GetExtension());
        }
    }
}
