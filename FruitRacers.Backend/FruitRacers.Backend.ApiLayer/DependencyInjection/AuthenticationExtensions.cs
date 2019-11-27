using FruitRacers.Backend.ApiLayer.Authentication;
using FruitRacers.Backend.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.DependencyInjection
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtVerification(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection appSettingsSection = config.GetSection(nameof(AuthenticationSettings));
            services.Configure<AuthenticationSettings>(appSettingsSection);
            AuthenticationSettings authSettings = appSettingsSection.Get<AuthenticationSettings>();
            byte[] key = Encoding.ASCII.GetBytes(authSettings.SecretKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            return services;
        }

        public static IServiceCollection AddAuthenticationHandler(this IServiceCollection services)
        {
            return services
                .AddSingleton<IHashCalculator, Pbkdf2Hashing>()
                .AddSingleton<ISaltGenerator, CspSaltGenerator>()
                .AddSingleton<IStringEncoding, HexEncoding>()
                .AddScoped<IAuthenticationHandler, JwtAuthentication>();
        }
    }
}
