using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class ProcedureService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public ProcedureService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("ProcedureService");
        }

        public async Task CreateAsync(ProcedureRequest request)
        {
            Procedure procedure = new Procedure((Guid)request.NurseId, (Guid)request.DeviceId, (Guid)request.AppointmentId);

            await applicationContext.Procedures.AddAsync(procedure);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<Procedure>> GetAll() =>
            await applicationContext.Procedures.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<Procedure> GetAsync(Guid id)
        {
            Procedure procedure = await applicationContext.Procedures.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (procedure == null) throw new Exception("Procedure with this identifier doesn`t exist.");

            return procedure;
        }

        public async Task DeleteAsync(Guid id)
        {
            Procedure procedure = applicationContext.Procedures.Find(id);

            if (procedure == null) throw new Exception("Procedure with this identifier doesn`t exist.");

            applicationContext.Procedures.Remove(procedure);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Procedure> EditAsync(Guid id, ProcedureRequest request)
        {
            Procedure newProcedure = new Procedure((Guid)request.NurseId, (Guid)request.DeviceId, (Guid)request.AppointmentId);
            Procedure procedure = await GetAsync(id);

            if (procedure == null) throw new Exception("Procedure with this identifier doesn`t exist.");

            procedure = newProcedure;
            procedure.Id = id;

            applicationContext.Procedures.Update(procedure);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(procedure.Id);
        }
    }
}
