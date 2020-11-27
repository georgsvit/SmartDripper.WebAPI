﻿using Microsoft.AspNetCore.DataProtection;
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
    public class AppointmentService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;

        public AppointmentService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            protector = provider.CreateProtector("AppointmentService");
            this.localizer = localizer;
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

            if (appointment == null) throw new Exception(localizer["Appointment with this identifier doesn`t exist."]);

            return appointment;
        }

        public async Task DeleteAsync(Guid id)
        {
            Appointment appointment = applicationContext.Appointments.Find(id);

            if (appointment == null) throw new Exception(localizer["Appointment with this identifier doesn`t exist."]);

            applicationContext.Appointments.Remove(appointment);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Appointment> EditAsync(Guid id, AppointmentRequest request)
        {
            Appointment newAppointment = new Appointment((Guid)request.MedicamentId, (Guid)request.PatientId, (Guid)request.DoctorId);
            Appointment appointment = await GetAsync(id);

            if (appointment == null) throw new Exception(localizer["Appointment with this identifier doesn`t exist."]);

            appointment = newAppointment;
            appointment.Id = id;

            applicationContext.Appointments.Update(appointment);
            await applicationContext.SaveChangesAsync();

            return await GetAsync(appointment.Id);
        }

        public async Task SetDoneAsync(Guid id)
        {
            Appointment appointment = await GetAsync(id);

            if (appointment == null) throw new Exception(localizer["Appointment with this identifier doesn`t exist."]);

            appointment.SetDone();
            
            applicationContext.Appointments.Update(appointment);
            await applicationContext.SaveChangesAsync();
        }
    }
}
