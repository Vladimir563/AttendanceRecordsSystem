using AttendanceRecordsSystem.Authentication.Interfaces;
using AttendanceRecordsSystem.Authentication.Models;
using AttendanceRecordsSystem.Authentication.Repositories;
using AttendanceRecordsSystem.Authentication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services,
            byte[] signingKey, IConfigurationSection settingsSection)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.SaveToken = true;
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                        ValidateLifetime = true,
                        LifetimeValidator = LifetimeValidator
                    };
                });

            services.Configure<AppSettings>(settingsSection);
            services.AddTransient<IUserCommandsRepository, UserCommandsRepository>();
            services.AddTransient<IUserQueriesRepository, UserQueriesRepository>();
            services.AddTransient<UserService>();
            services.AddTransient<AuthenticationService>();
            services.AddTransient<TokenService>();

            return services;
        }

        private static bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires,
            SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            return expires != null && expires > DateTime.Now;
        }
    }
}
