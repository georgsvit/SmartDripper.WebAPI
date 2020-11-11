using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDripper.WebAPI.ServiceInstallations;
using SmartDripper.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.ServiceInstallers.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AdminService>();
            services.AddTransient<NurseService>();
            services.AddTransient<DoctorService>();
            services.AddTransient<JWTTokenService>();
        }
    }
}
