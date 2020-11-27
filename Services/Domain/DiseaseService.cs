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
    public class DiseaseService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public DiseaseService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("DiseaseService");
            this.localizer = localizer;
        }

        public async Task CreateAsync(DiseaseRequest request)
        {
            Disease disease = new Disease(request.Title, request.SymptomUk, request.SymptomUa);

            var inBase = await applicationContext.Diseases.FirstOrDefaultAsync(x => x.Title == request.Title);

            if (inBase != null) throw new Exception(localizer["Disease already exists."]);

            await applicationContext.Diseases.AddAsync(disease);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<Disease>> GetAll() =>
            await applicationContext.Diseases.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<Disease> GetAsync(Guid id)
        {
            Disease disease = await applicationContext.Diseases.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (disease == null) throw new Exception(localizer["Disease with this identifier doesn`t exist."]);

            return disease;
        }

        public async Task DeleteAsync(Guid id)
        {
            Disease disease = applicationContext.Diseases.Find(id);

            if (disease == null) throw new Exception(localizer["Disease with this identifier doesn`t exist."]);

            applicationContext.Diseases.Remove(disease);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Disease> EditAsync(Guid id, DiseaseRequest request)
        {
            Disease newDisease = new Disease(request.Title, request.SymptomUk, request.SymptomUa);
            Disease disease = await GetAsync(id);

            if (disease == null) throw new Exception(localizer["Disease with this identifier doesn`t exist."]);

            disease = newDisease;
            disease.Id = id;

            applicationContext.Diseases.Update(disease);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(disease.Id);
        }
    }
}
