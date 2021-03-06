﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDripper.WebAPI.Data;

namespace SmartDripper.WebAPI.ServiceInstallations.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            string connection = configuration.GetConnectionString("DevConnection");
#else
            string connection = configuration.GetConnectionString("ReleaseConnection");
#endif

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection)
            );
        }
    }
}
