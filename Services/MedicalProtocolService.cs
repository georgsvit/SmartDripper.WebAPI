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
    public class MedicalProtocolService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public MedicalProtocolService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("MedicalProtocolService");
        }

        public async Task CreateAsync(MedicalProtocolRequest request)
        {
            MedicalProtocol medicalProtocol = new MedicalProtocol((Guid)request.DiseaseId, request.Title, request.Description, request.MaxTemp, request.MinTemp, request.MaxPulse, request.MinPulse, request.MaxBloodPressure, request.MinBloodPressure);

            var inBase = await applicationContext.MedicalProtocols.FirstOrDefaultAsync(x => x.Title == request.Title);

            if (inBase != null) throw new Exception("MedicalProtocol already exists.");

            await applicationContext.MedicalProtocols.AddAsync(medicalProtocol);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<MedicalProtocol>> GetAll() =>
            await applicationContext.MedicalProtocols.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<MedicalProtocol> GetAsync(Guid id)
        {
            MedicalProtocol medicalProtocol = await applicationContext.MedicalProtocols.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (medicalProtocol == null) throw new Exception("MedicalProtocol with this identifier doesn`t exist.");

            return medicalProtocol;
        }

        public async Task DeleteAsync(Guid id)
        {
            MedicalProtocol medicalProtocol = applicationContext.MedicalProtocols.Find(id);

            if (medicalProtocol == null) throw new Exception("MedicalProtocol with this identifier doesn`t exist.");

            applicationContext.MedicalProtocols.Remove(medicalProtocol);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<MedicalProtocol> EditAsync(Guid id, MedicalProtocolRequest request)
        {
            MedicalProtocol newMedicalProtocol = new MedicalProtocol((Guid)request.DiseaseId, request.Title, request.Description, request.MaxTemp, request.MinTemp, request.MaxPulse, request.MinPulse, request.MaxBloodPressure, request.MinBloodPressure);
            MedicalProtocol medicalProtocol = await GetAsync(id);

            if (medicalProtocol == null) throw new Exception("MedicalProtocol with this identifier doesn`t exist.");

            medicalProtocol = newMedicalProtocol;
            medicalProtocol.Id = id;

            applicationContext.MedicalProtocols.Update(medicalProtocol);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(medicalProtocol.Id);
        }
    }
}