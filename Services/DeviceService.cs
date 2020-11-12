using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class DeviceService : GenericUserService
    {
        public DeviceService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider) 
            : base(applicationContext, tokenService, provider) { }

        public async Task<DeviceResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Devices.FindAsync(identity.Id);
            if (user == null) throw new Exception("Login failed. The user is not an device.");

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new DeviceResponse(user.State, user.IsTurnedOn, encodedToken, token.ValidTo);
        }

        public async Task DeleteAsync(Guid deviceId, Guid identityId)
        {
            Device device = await applicationContext.Devices.Include(d => d.UserIdentity).FirstOrDefaultAsync(d => d.Id == deviceId);
            UserIdentity identity = device.UserIdentity;

            if (identity == null || device == null) throw new Exception("Cannot delete this device.");

            applicationContext.Devices.Remove(device);
            await applicationContext.SaveChangesAsync();

            applicationContext.UserIdentities.Remove(identity);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<Device>> GetAllDevicesAsync() =>
            await applicationContext.Devices
                .Include(d => d.UserIdentity)
                .Include(d => d.Procedure)
                .ThenInclude(p => p.Nurse)
                .Include(d => d.Procedure)
                .ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
                .Include(d => d.Procedure)
                .ThenInclude(p => p.Appointment).ThenInclude(a => a.Medicament).ThenInclude(m => m.MedicalProtocol).ThenInclude(mp => mp.Disease)
                .ToListAsync();

        public async Task<Device> GetOneAsync(Guid deviceId)
        {
            Device device = await applicationContext.Devices
                .Include(d => d.UserIdentity)
                .Include(d => d.Procedure)
                .ThenInclude(p => p.Nurse)
                .Include(d => d.Procedure)
                .ThenInclude(p => p.Appointment).ThenInclude(a => a.Patient)
                .Include(d => d.Procedure)
                .ThenInclude(p => p.Appointment).ThenInclude(a => a.Medicament).ThenInclude(m => m.MedicalProtocol).ThenInclude(mp => mp.Disease)
                .FirstOrDefaultAsync(d => d.Id == deviceId);

            if (device == null) throw new Exception("Device with this identifier doesn`t exist");
            return device;
        }
                 
        public async Task ResetAsync(Guid identityId, string newPassword)
        {
            var identity = await applicationContext.UserIdentities.FindAsync(identityId);
            if (identity == null)
            {
                throw new Exception("The user with such id was not found.");
            }

            var smartDevice = await applicationContext.Devices.FindAsync(identity.Id);
            if (smartDevice == null)
            {
                throw new Exception("The user with such id is not a smart device.");
            }

            string login = identity.Login;
            await DeleteAsync(identity.Id, smartDevice.Id);
            await RegisterAsync(new Device(login, newPassword));
        }

        public async Task UpdateConfigurationAsync(Guid deviceId, DeviceUpdateRequest request)
        {
            Device device = await GetOneAsync(deviceId);

            device.IsTurnedOn = request.IsTurnedOn;
            device.State = request.DeviceState;
            if (request.ProcedureId != null) device.Procedure = await applicationContext.Procedures.FindAsync(request.ProcedureId);

            await applicationContext.SaveChangesAsync();
            // TODO: Send message to iot
        }
    }
}
