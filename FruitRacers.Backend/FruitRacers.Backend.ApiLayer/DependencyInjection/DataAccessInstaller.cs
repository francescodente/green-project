﻿using FruitRacers.Backend.ApiLayer.Utils;
using FruitRacers.Backend.Core.Logic;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Core.Utils.Time;
using FruitRacers.Backend.DataAccess.Sql;
using FruitRacers.Backend.Infrastructure.Time;
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

            services.AddScoped<IDataSession>(p => p.GetRequiredService<FruitracersContext>());

            services.AddScoped<IDateTime, MachineDateTime>();
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
                .AddScoped<ISupportService, SupportService>()
                .AddScoped<IImagesService, ImagesService>()
                .AddScoped<IOrdersService, OrdersService>();
        }
    }
}
