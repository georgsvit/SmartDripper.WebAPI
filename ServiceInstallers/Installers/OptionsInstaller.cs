using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDripper.WebAPI.Options;
using SmartDripper.WebAPI.ServiceInstallations;

namespace SmartDripper.WebAPI.ServiceInstallers.Installers
{
    public class OptionsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.SectionName));
        }
    }
}
