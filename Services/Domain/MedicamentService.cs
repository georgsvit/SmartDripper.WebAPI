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
    public class MedicamentService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public MedicamentService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("MedicamentService");
            this.localizer = localizer;
        }

        public async Task CreateAsync(MedicamentRequest request)
        {
            Medicament medicament = new Medicament(request.Title, request.Description, request.ManufacturerId, request.MedicalProtocolId);

            var inBase = await applicationContext.Medicaments.FirstOrDefaultAsync(x => x.Title == request.Title && x.Description == request.Description);

            if (inBase != null) throw new Exception(localizer["Medicament already exists."]);

            await applicationContext.Medicaments.AddAsync(medicament);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<Medicament>> GetAll() =>
            await applicationContext.Medicaments.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<Medicament> GetAsync(Guid id)
        {
            Medicament medicament = await applicationContext.Medicaments.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (medicament == null) throw new Exception(localizer["Medicament with this identifier doesn`t exist."]);

            return medicament;
        }

        public async Task DeleteAsync(Guid id)
        {
            Medicament medicament = applicationContext.Medicaments.Find(id);

            if (medicament == null) throw new Exception(localizer["Medicament with this identifier doesn`t exist."]);

            applicationContext.Medicaments.Remove(medicament);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Medicament> EditAsync(Guid id, MedicamentRequest request)
        {
            Medicament newMedicament = new Medicament(request.Title, request.Description, request.ManufacturerId, request.MedicalProtocolId);
            Medicament medicament = await GetAsync(id);

            if (medicament == null) throw new Exception(localizer["Medicament with this identifier doesn`t exist."]);

            medicament = newMedicament;
            medicament.Id = id;

            applicationContext.Medicaments.Update(medicament);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(medicament.Id);
        }
    }
}
