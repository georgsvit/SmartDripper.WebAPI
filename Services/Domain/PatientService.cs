using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class PatientService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public PatientService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("PatientService");
            this.localizer = localizer;
        }

        public async Task CreateAsync(PatientRequest request)
        {
            Patient patient = Protect(request);

            var inBase = await applicationContext.Patients.FirstOrDefaultAsync(x => x.Name == patient.Name
                                                                            && x.Surname == patient.Surname
                                                                            && x.DOB == patient.DOB);

            if (inBase != null) throw new Exception(localizer["Patient already exists."]);

            await applicationContext.Patients.AddAsync(patient);
            await applicationContext.SaveChangesAsync();
        }

        private PatientResponse Unprotect(Patient patient) =>
            new PatientResponse
            {
                Id = patient.Id,
                Name = protector.Unprotect(patient.Name),
                Surname = protector.Unprotect(patient.Surname),
                DOB = DateTime.Parse(protector.Unprotect(patient.DOB)),
                Comment = protector.Unprotect(patient.Comment)
            };

        public string UnprotectData(String data)
        {
            return protector.Unprotect(data);
        }

        private Patient Protect(PatientRequest request) =>
            new Patient(
                protector.Protect(request.Name),
                protector.Protect(request.Surname),
                protector.Protect(request.DOB.ToString()),
                protector.Protect(request.Comment));

        // TODO: Get all adjacent data
        public async Task<List<PatientResponse>> GetAll()
        {
            var list = await applicationContext.Patients.ToListAsync();
            var outputList = new List<PatientResponse>();

            foreach (var i in list) outputList.Add(Unprotect(i));
            return outputList;
        }

        // TODO: Get all adjacent data
        public async Task<PatientResponse> GetPatientResponseAsync(Guid id)
        {
            Patient patient = await applicationContext.Patients.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (patient == null) throw new Exception(localizer["Patient with this identifier doesn`t exist."]);

            return Unprotect(patient);
        }

        // TODO: Get all adjacent data
        public async Task<Patient> GetAsync(Guid id)
        {
            Patient patient = await applicationContext.Patients.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (patient == null) throw new Exception(localizer["Patient with this identifier doesn`t exist."]);

            return patient;
        }

        public async Task DeleteAsync(Guid id)
        {
            Patient patient = applicationContext.Patients.Find(id);

            if (patient == null) throw new Exception(localizer["Patient with this identifier doesn`t exist."]);

            applicationContext.Patients.Remove(patient);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<PatientResponse> EditAsync(Guid id, PatientRequest request)
        {
            Patient newPatient = Protect(request);
            Patient patient = await GetAsync(id);

            if (patient == null) throw new Exception(localizer["Patient with this identifier doesn`t exist."]);

            patient = newPatient;
            patient.Id = id;

            applicationContext.Patients.Update(patient);
            await applicationContext.SaveChangesAsync();

            return await GetPatientResponseAsync(patient.Id);
        }
    }
}
