using FruitRacers.Backend.ApiLayer.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Services.Impl;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.DataAccess.Sql;
using FruitRacers.Backend.Infrastructure.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public class DataAccessInstaller : IServiceInstaller
    {
        private const string CONNECTION_STRING_KEY = "FruitracersDb";

        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FruitracersContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString(CONNECTION_STRING_KEY));
            });

            services.AddScoped<IDataSession>(p => new LazyLoadedDataSession(
                new SqlDataSession(p.GetRequiredService<FruitracersContext>())
            ));

            services.AddScoped<IUserSession, UserSession>();

            services.AddScoped<IRequestSession, RequestSession>();

            services
                .AddScoped<IAddressesService, AddressesService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<ICartService, CartService>()
                .AddScoped<ICategoriesService, CategoriesService>()
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<ISuppliersService, SuppliersService>()
                .AddScoped<ITimeSlotsService, TimeSlotsService>()
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<IRolesService, RolesService>()
                .AddScoped<ISupportService, SupportService>();
        }
    }
}
