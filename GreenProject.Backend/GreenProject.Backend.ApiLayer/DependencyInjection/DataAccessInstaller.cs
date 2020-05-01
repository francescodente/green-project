using GreenProject.Backend.ApiLayer.Utils;
using GreenProject.Backend.Core.Logic;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.DataAccess.Sql;
using GreenProject.Backend.Infrastructure.Time;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class DataAccessInstaller : IServiceInstaller
    {
        private const string CONNECTION_STRING_KEY = "GreenProjectDb";

        public void InstallServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddDbContext<GreenProjectContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString(CONNECTION_STRING_KEY));
            });

            services.AddScoped<IDataSession>(p => p.GetRequiredService<GreenProjectContext>());

            services.AddScoped<IDateTime, MachineDateTime>();
            services.AddScoped<IUserSession, UserSession>();

            services.AddScoped<IRequestSession, RequestSession>();

            services.AddScoped<IOrderScheduler, DefaultOrderScheduler>();

            services
                .AddScoped<IAddressesService, AddressesService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<ICartService, CartService>()
                .AddScoped<ICategoriesService, CategoriesService>()
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<ICratesService, CratesService>()
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<IRolesService, RolesService>()
                .AddScoped<ISupportService, SupportService>()
                .AddScoped<IImagesService, ImagesService>()
                .AddScoped<IZonesService, ZonesService>()
                .AddScoped<IOrdersService, OrdersService>()
                .AddScoped<IWeeklyOrdersService, WeeklyOrdersService>()
                .AddScoped<IReportsService, ReportsService>();
        }
    }
}
