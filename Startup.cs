using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SmartDripper.WebAPI.Extensions;
using SmartDripper.WebAPI.Options;
using System.Globalization;
using System.Linq;

namespace SmartDripper.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<CultureOptions> cultureOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SetCultureConfigurationValues(cultureOptions, out string defaultCultureName, out CultureInfo[] supportedCultures);

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCultureName),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void SetCultureConfigurationValues(
            IOptions<CultureOptions> cultureOptions, out string defaultCultureName, out CultureInfo[] supportedCultures)
        {
            CultureOptions cultureOptionsValue = cultureOptions.Value;
            defaultCultureName = cultureOptionsValue.DefaultCulture;
            supportedCultures = cultureOptionsValue.SupportedCultures.Select(culture => new CultureInfo(culture)).ToArray();
        }
    }
}
