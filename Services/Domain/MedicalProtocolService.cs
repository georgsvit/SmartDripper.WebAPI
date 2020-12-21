using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class MedicalProtocolService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public MedicalProtocolService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("MedicalProtocolService");
            this.localizer = localizer;
        }

        public async Task CreateAsync(MedicalProtocolRequest request)
        {
            MedicalProtocol medicalProtocol = new MedicalProtocol((Guid)request.DiseaseId, request.Title, request.Description, request.MaxTemp, request.MinTemp, request.MaxPulse, request.MinPulse, request.MaxBloodPressure, request.MinBloodPressure);

            var inBase = await applicationContext.MedicalProtocols.FirstOrDefaultAsync(x => x.Title == request.Title);

            if (inBase != null) throw new Exception(localizer["MedicalProtocol already exists."]);

            await applicationContext.MedicalProtocols.AddAsync(medicalProtocol);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<MedicalProtocol>> GetAll() =>
            await applicationContext.MedicalProtocols.Include(mp => mp.Disease).ToListAsync();

        // TODO: Get all adjacent data
        public async Task<MedicalProtocol> GetAsync(Guid id)
        {
            MedicalProtocol medicalProtocol = await applicationContext.MedicalProtocols.Include(mp => mp.Disease).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (medicalProtocol == null) throw new Exception(localizer["MedicalProtocol with this identifier doesn`t exist."]);

            return medicalProtocol;
        }

        public async Task DeleteAsync(Guid id)
        {
            MedicalProtocol medicalProtocol = applicationContext.MedicalProtocols.Find(id);

            if (medicalProtocol == null) throw new Exception(localizer["MedicalProtocol with this identifier doesn`t exist."]);

            applicationContext.MedicalProtocols.Remove(medicalProtocol);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<MedicalProtocol> EditAsync(Guid id, MedicalProtocolRequest request)
        {
            MedicalProtocol newMedicalProtocol = new MedicalProtocol((Guid)request.DiseaseId, request.Title, request.Description, request.MaxTemp, request.MinTemp, request.MaxPulse, request.MinPulse, request.MaxBloodPressure, request.MinBloodPressure);
            MedicalProtocol medicalProtocol = await GetAsync(id);

            if (medicalProtocol == null) throw new Exception(localizer["MedicalProtocol with this identifier doesn`t exist."]);

            medicalProtocol = newMedicalProtocol;
            medicalProtocol.Id = id;

            applicationContext.MedicalProtocols.Update(medicalProtocol);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(medicalProtocol.Id);
        }
    }
}
