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
    public class AppointmentService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;

        public AppointmentService(ApplicationContext applicationContext, IDataProtectionProvider provider)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("AppointmentService");
        }

        public async Task CreateAsync(AppointmentRequest request)
        {
            Appointment appointment = new Appointment((Guid)request.MedicamentId, (Guid)request.PatientId, (Guid)request.DoctorId);

            await applicationContext.Appointments.AddAsync(appointment);
            await applicationContext.SaveChangesAsync();
        }

        // TODO: Get all adjacent data
        public async Task<List<Appointment>> GetAll() =>
            await applicationContext.Appointments.ToListAsync();

        // TODO: Get all adjacent data
        public async Task<Appointment> GetAsync(Guid id)
        {
            Appointment appointment = await applicationContext.Appointments.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (appointment == null) throw new Exception("Appointment with this identifier doesn`t exist.");

            return appointment;
        }

        public async Task DeleteAsync(Guid id)
        {
            Appointment appointment = applicationContext.Appointments.Find(id);

            if (appointment == null) throw new Exception("Appointment with this identifier doesn`t exist.");

            applicationContext.Appointments.Remove(appointment);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Appointment> EditAsync(Guid id, AppointmentRequest request)
        {
            Appointment newAppointment = new Appointment((Guid)request.MedicamentId, (Guid)request.PatientId, (Guid)request.DoctorId);
            Appointment appointment = await GetAsync(id);

            if (appointment == null) throw new Exception("Appointment with this identifier doesn`t exist.");

            appointment = newAppointment;
            appointment.Id = id;

            applicationContext.Appointments.Update(appointment);
            applicationContext.SaveChanges();

            return await GetAsync(appointment.Id);
        }
    }
}
