﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartDripper.WebAPI.Options;

namespace SmartDripper.WebAPI.ServiceInstallations.Installers
{
    public class JWTAuthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var JWTOptions = new JWTOptions();
            configuration.GetSection(JWTOptions.SectionName).Bind(JWTOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JWTOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = JWTOptions.Audience,

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = JWTOptions.GetSymmetricSecurityKey()
                    };
                });
        }
    }
}
