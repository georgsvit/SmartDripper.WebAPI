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
    public class ProcedureService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public ProcedureService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("ProcedureService");
            this.localizer = localizer;
        }

        public async Task CreateAsync(ProcedureRequest request)
        {
            Procedure procedure = new Procedure((Guid)request.NurseId, (Guid)request.DeviceId, (Guid)request.AppointmentId);

            Procedure isInBase = await applicationContext.Procedures.FirstOrDefaultAsync(p => p.AppointmentId == procedure.AppointmentId);

            if (isInBase != null) throw new Exception(localizer["Procedure already exists."]);         

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

            if (procedure == null) throw new Exception(localizer["Procedure with this identifier doesn`t exist."]);

            return procedure;
        }

        public async Task DeleteAsync(Guid id)
        {
            Procedure procedure = applicationContext.Procedures.Find(id);

            if (procedure == null) throw new Exception(localizer["Procedure with this identifier doesn`t exist."]);

            applicationContext.Procedures.Remove(procedure);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Procedure> EditAsync(Guid id, ProcedureRequest request)
        {
            Procedure newProcedure = new Procedure((Guid)request.NurseId, (Guid)request.DeviceId, (Guid)request.AppointmentId);
            Procedure procedure = await GetAsync(id);

            if (procedure == null) throw new Exception(localizer["Procedure with this identifier doesn`t exist."]);

            procedure = newProcedure;
            procedure.Id = id;

            applicationContext.Procedures.Update(procedure);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(procedure.Id);
        }

        public async Task<Procedure> GetProcedureByAppointmentId(Guid appointmentId)
        {            
            var procedure = await applicationContext.Procedures.Include(p => p.Appointment).FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);

            if (procedure == null) throw new Exception(localizer["Procedure with this identifier doesn`t exist."]);

            return procedure;
        }
    }
}
