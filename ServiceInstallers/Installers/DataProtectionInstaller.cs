using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDripper.WebAPI.ServiceInstallations;

namespace SmartDripper.WebAPI.ServiceInstallers.Installers
{
    public class DataProtectionInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataProtection();
        }
    }
}
