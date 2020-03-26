using GreenProject.Backend.ApiLayer.Authentication;
using GreenProject.Backend.Core.Utils;
using GreenProject.Backend.Infrastructure.PasswordHashing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace GreenProject.Backend.ApiLayer.DependencyInjection
{
    public class AuthenticationInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration config)
        {
            services
                .AddSingleton<IHashCalculator, Pbkdf2Hashing>()
                .AddSingleton<ISaltGenerator, CspSaltGenerator>()
                .AddSingleton<IStringEncoding, HexEncoding>()
                .AddScoped<IAuthenticationHandler, JwtAuthentication>();

            IConfiguration authSection = config.GetSection(nameof(AuthenticationSettings));
            AuthenticationSettings authSettings = authSection.Get<AuthenticationSettings>();
            services.AddSingleton(authSettings);

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

            services.AddAuthorization();
        }
    }
}
