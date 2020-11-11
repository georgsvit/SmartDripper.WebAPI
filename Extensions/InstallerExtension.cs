using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDripper.WebAPI.ServiceInstallations;
using System;
using System.Linq;
using System.Reflection;

namespace SmartDripper.WebAPI.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly.GetAssembly(typeof(Startup))?
                .GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && typeof(IInstaller).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList()
                .ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
