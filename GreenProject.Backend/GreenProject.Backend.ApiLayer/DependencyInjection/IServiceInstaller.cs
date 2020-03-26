using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public interface IServiceInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration config);
    }
}
