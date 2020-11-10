using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDripper.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.ServiceInstallations.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            string connectionString = configuration.GetConnectionString("DevConnection");
#else
            string connectionString = configuration.GetConnectionString("ReleaseConnection");
#endif

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
