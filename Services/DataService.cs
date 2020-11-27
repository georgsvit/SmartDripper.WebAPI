using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Contracts;
using SmartDripper.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class DataService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public DataService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("PatientService");
        }

        public async Task<byte[]> ExportAsync()
        {
            DataDTO data = await LoadDataToDTOAsync();
            string jsonData = JsonSerializer.Serialize(data);

            string jsonDataEncoded = protector.Protect(jsonData);
            return Encoding.UTF8.GetBytes(jsonDataEncoded);
        }

        public async Task ImportAsync(byte[] importFileContent)
        {
            string serviceDataJson = GetOriginalServiceDataJson(importFileContent);
            DataDTO serviceData = JsonSerializer.Deserialize<DataDTO>(serviceDataJson);
            await LoadDataToDatabaseAsync(serviceData);
        }

        private async Task<DataDTO> LoadDataToDTOAsync()
        {
            Guid defaultAdminGuid = new Guid("1EC7309F-C97D-412C-B8B8-31C1459CBD41");

            return new DataDTO
            (
                await applicationContext.Admins.AsNoTracking().Where(a => a.Id != defaultAdminGuid).ToListAsync(),
                await applicationContext.Devices.AsNoTracking().ToListAsync(),
                await applicationContext.Doctors.AsNoTracking().ToListAsync(),
                await applicationContext.Nurses.AsNoTracking().ToListAsync(),
                await applicationContext.UserIdentities.AsNoTracking().Where(i => i.Id != defaultAdminGuid).ToListAsync(),
                await applicationContext.Appointments.AsNoTracking().ToListAsync(),
                await applicationContext.Diseases.AsNoTracking().ToListAsync(),
                await applicationContext.Manufacturers.AsNoTracking().ToListAsync(),
                await applicationContext.MedicalProtocols.AsNoTracking().ToListAsync(),
                await applicationContext.Medicaments.AsNoTracking().ToListAsync(),
                await applicationContext.MedicamentLogNotes.AsNoTracking().ToListAsync(),
                await applicationContext.Orders.AsNoTracking().ToListAsync(),
                await applicationContext.Patients.AsNoTracking().ToListAsync(),
                await applicationContext.Procedures.AsNoTracking().ToListAsync()
            );
        }

        private string GetOriginalServiceDataJson(byte[] importFileContent)
        {
            string serviceDataJsonEncoded = Encoding.UTF8.GetString(importFileContent);
            return protector.Unprotect(serviceDataJsonEncoded);
        }

        private async Task LoadDataToDatabaseAsync(DataDTO serviceData)
        {
            await applicationContext.UserIdentities.AddRangeAsync(serviceData.UserIdentities);
            await applicationContext.Admins.AddRangeAsync(serviceData.Admins);
            await applicationContext.Appointments.AddRangeAsync(serviceData.Appointments);
            await applicationContext.Devices.AddRangeAsync(serviceData.Devices);
            await applicationContext.Diseases.AddRangeAsync(serviceData.Diseases);
            await applicationContext.Doctors.AddRangeAsync(serviceData.Doctors);
            await applicationContext.Manufacturers.AddRangeAsync(serviceData.Manufacturers);
            await applicationContext.MedicalProtocols.AddRangeAsync(serviceData.MedicalProtocols);
            await applicationContext.MedicamentLogNotes.AddRangeAsync(serviceData.MedicamentLogNotes);
            await applicationContext.Medicaments.AddRangeAsync(serviceData.Medicaments);
            await applicationContext.Nurses.AddRangeAsync(serviceData.Nurses);
            await applicationContext.Orders.AddRangeAsync(serviceData.Orders);
            await applicationContext.Patients.AddRangeAsync(serviceData.Patients);
            await applicationContext.Procedures.AddRangeAsync(serviceData.Procedures);
            

            await applicationContext.SaveChangesAsync();
        }

    }
}
