using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class UserService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IDataProtector protector;
        private readonly IStringLocalizer localizer;
        private readonly NurseService nurseService;
        private readonly DoctorService doctorService;

        public UserService(ApplicationContext applicationContext, IDataProtectionProvider provider, IStringLocalizer localizer, NurseService nurseService, DoctorService doctorService)
        {
            this.applicationContext = applicationContext;
            this.protector = provider.CreateProtector("UserService");
            this.localizer = localizer;
            this.nurseService = nurseService;
            this.doctorService = doctorService;
        }

        public async Task CreateAsync(DetailedRegistrationRequest request, string role)
        {

            if (role == "NURSE")
            {
                Nurse nurse = new Nurse(request.Login, request.Password, request.Name, request.Surname);
                await nurseService.RegisterAsync(nurse);
            }

            if (role == "DOCTOR")
            {
                Doctor doctor = new Doctor(request.Login, request.Password, request.Name, request.Surname);
                await doctorService.RegisterAsync(doctor);
            }
        }

        public async Task<List<DetailedUserResponse>> GetAll(string role)
        {
            List<DetailedUserResponse> list = new List<DetailedUserResponse>();
            switch (role)
            {
                case "NURSE":
                    list = applicationContext.Nurses.Include(n => n.UserIdentity).Select(n => new DetailedUserResponse(n.Id, n.Name, n.Surname, n.UserIdentity.Role, "", DateTime.Now)).ToList();
                    break;
                case "DOCTOR":
                    list = applicationContext.Doctors.Include(n => n.UserIdentity).Select(d => new DetailedUserResponse(d.Id, d.Name, d.Surname, d.UserIdentity.Role, "", DateTime.Now)).ToList();
                    break;
                default:
                    list = applicationContext.Nurses.Include(n => n.UserIdentity).Select(n => new DetailedUserResponse(n.Id, n.Name, n.Surname, n.UserIdentity.Role, "", DateTime.Now)).ToList();
                    list.AddRange(applicationContext.Doctors.Include(n => n.UserIdentity).Select(d => new DetailedUserResponse(d.Id, d.Name, d.Surname, d.UserIdentity.Role, "", DateTime.Now)).ToList());
                    break;
            }
            return list;
        }

        public async Task DeleteAsync(Guid id, string role)
        {
            UserIdentity identity = null;
            if (role == "NURSE")
            {
                Nurse nurse = await applicationContext.Nurses.Include(n => n.UserIdentity).FirstOrDefaultAsync(x => x.Id == id);
                if (nurse == null) throw new Exception(localizer["The user with such login doesn`t exist."]);

                identity = nurse.UserIdentity;
                applicationContext.Nurses.Remove(nurse);
            }

            if (role == "DOCTOR")
            {
                Doctor doctor = await applicationContext.Doctors.Include(d => d.UserIdentity).FirstOrDefaultAsync(x => x.Id == id);
                if (doctor == null) throw new Exception(localizer["The user with such login doesn`t exist."]);

                identity = doctor.UserIdentity;
                applicationContext.Doctors.Remove(doctor);
            }

            await applicationContext.SaveChangesAsync();
            if (identity != null)
            {
                applicationContext.UserIdentities.Remove(identity);
                await applicationContext.SaveChangesAsync();
            }            
        }

        public async Task EditAsync(Guid id, DetailedRegistrationRequest request, string role)
        {
            if (role == "NURSE")
            {
                Nurse newNurse = new Nurse(request.Login, request.Password, request.Name, request.Surname);
                Nurse nurse = await applicationContext.Nurses.Include(n => n.UserIdentity).AsNoTracking().SingleOrDefaultAsync(n => n.Id == id);

                if (nurse == null) throw new Exception(localizer["The user with such login doesn`t exist."]);

                request.Password = nurse.UserIdentity.Password;
                request.Login = nurse.UserIdentity.Login;

                await DeleteAsync(nurse.Id, role);
                await CreateAsync(request, role);
            }

            if (role == "DOCTOR")
            {
                Doctor newDoctor = new Doctor(request.Login, request.Password, request.Name, request.Surname);
                Doctor doctor = await applicationContext.Doctors.Include(d => d.UserIdentity).AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);

                if (doctor == null) throw new Exception(localizer["The user with such login doesn`t exist."]);

                request.Password = doctor.UserIdentity.Password;
                request.Login = doctor.UserIdentity.Login;

                await DeleteAsync(doctor.Id, role);
                await CreateAsync(request, role);
            }

            await applicationContext.SaveChangesAsync();
        }
    }
}
