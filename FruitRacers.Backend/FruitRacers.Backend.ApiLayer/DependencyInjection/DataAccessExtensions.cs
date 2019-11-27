using FruitRacers.Backend.Core;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Services.Impl;
using FruitRacers.Backend.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public static class DataAccessExtensions
    {
        private const string CONNECTION_STRING_KEY = "FruitracersDb";

        public static IServiceCollection AddDataSession(this IServiceCollection services)
        {
            return services.AddScoped<IDataSession, SqlDataSession>();
        }

        public static IServiceCollection AddSqlServerConnection(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<FruitracersContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING_KEY));
            });
        }

        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IAddressesService, AddressesService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<ICartService, CartService>()
                .AddScoped<ICategoriesService, CategoriesService>()
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<ISuppliersService, SuppliersService>()
                .AddScoped<ITimeSlotsService, TimeSlotsService>()
                .AddScoped<IUsersService<PersonDto>, PeopleUsersService>()
                .AddScoped<IUsersService<SupplierDto>, SuppliersUsersService>()
                .AddScoped<IUsersService<CustomerBusinessDto>, CustomerBusinessUsersService>();
        }
    }
}
