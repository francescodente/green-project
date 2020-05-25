using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public interface IServiceInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env);
    }
}
