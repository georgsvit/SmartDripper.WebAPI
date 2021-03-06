﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.ServiceInstallations;
using SmartDripper.WebAPI.Services;
using SmartDripper.WebAPI.Services.Domain;

namespace SmartDripper.WebAPI.ServiceInstallers.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AdminService>();
            services.AddTransient<NurseService>();
            services.AddTransient<DoctorService>();
            services.AddTransient<DeviceService>();
            services.AddTransient<UserService>();

            //
            services.AddTransient<MedicamentService>();
            services.AddTransient<DiseaseService>();
            services.AddTransient<MedicalProtocolService>();
            services.AddTransient<ManufacturerService>();
            services.AddTransient<PatientService>();
            services.AddTransient<AppointmentService>();
            services.AddTransient<ProcedureService>();
            services.AddTransient<OrderService>();
            services.AddTransient<MedicamentLogNoteService>();

            //
            services.AddTransient<JWTTokenService>();
            services.AddTransient<IStringLocalizer, LocalizationService>();
            services.AddTransient<DataService>();
            services.AddTransient<DeviceHubService>();
        }
    }
}
