﻿using Microsoft.AspNetCore.DataProtection;
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
    public class MedicamentService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public MedicamentService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("MedicamentService");
        }

        public async Task CreateAsync(MedicamentRequest request)
        {
            Medicament medicament = new Medicament(request.Title, request.Description, request.ManufacturerId, request.MedicalProtocolId);

            var a = await applicationContext.Medicaments.FirstOrDefaultAsync(m => m.Title == request.Title && m.Description == request.Description);

            if (a != null) throw new Exception("Medicament already exists.");

            await applicationContext.Medicaments.AddAsync(medicament);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<Medicament>> GetAll() =>
            await applicationContext.Medicaments.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<Medicament> GetAsync(Guid id)
        {          
            Medicament medicament = await applicationContext.Medicaments.FindAsync(id);

            if (medicament == null) throw new Exception("Medicament with this identifier doesn`t exist.");

            return medicament;
        }

        public async Task DeleteAsync(Guid id)
        {
            Medicament medicament = applicationContext.Medicaments.Find(id);

            if (medicament == null) throw new Exception("Medicament with this identifier doesn`t exist.");

            applicationContext.Medicaments.Remove(medicament);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Medicament> EditAsync(Guid id, MedicamentRequest request)
        {
            Medicament newMedicament = new Medicament(request.Title, request.Description, request.ManufacturerId, request.MedicalProtocolId);
            Medicament medicament = await GetAsync(id);

            if (medicament == null) throw new Exception("Medicament with this identifier doesn`t exist.");

            applicationContext.Medicaments.Update(newMedicament);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(medicament.Id);
        }
    }
}