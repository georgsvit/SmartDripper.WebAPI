using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class DiseaseService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public DiseaseService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("DiseaseService");
        }

        public async Task CreateAsync(DiseaseRequest request)
        {
            Disease disease = new Disease(request.Title, request.SymptomUk, request.SymptomUa);

            var inBase = await applicationContext.Diseases.FirstOrDefaultAsync(x => x.Title == request.Title);

            if (inBase != null) throw new Exception("Disease already exists.");

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

            if (disease == null) throw new Exception("Disease with this identifier doesn`t exist.");

            return disease;
        }

        public async Task DeleteAsync(Guid id)
        {
            Disease disease = applicationContext.Diseases.Find(id);

            if (disease == null) throw new Exception("Disease with this identifier doesn`t exist.");

            applicationContext.Diseases.Remove(disease);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Disease> EditAsync(Guid id, DiseaseRequest request)
        {
            Disease newDisease = new Disease(request.Title, request.SymptomUk, request.SymptomUa);
            Disease disease = await GetAsync(id);

            if (disease == null) throw new Exception("Disease with this identifier doesn`t exist.");

            disease = newDisease;
            disease.Id = id;

            applicationContext.Diseases.Update(disease);
            applicationContext.SaveChanges();

            return await GetAsync(disease.Id);
        }
    }
}
