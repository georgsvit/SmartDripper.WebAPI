using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartDripper.WebAPI.Contracts.DTORequests;
using SmartDripper.WebAPI.Contracts.DTORequests.Device;
using SmartDripper.WebAPI.Contracts.DTOResponses;
using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class DeviceService : GenericUserService
    {
        private readonly DeviceHubService deviceHubService;
        private readonly IDataProtector protector;

        public DeviceService(ApplicationContext applicationContext, JWTTokenService tokenService, IDataProtectionProvider provider, IStringLocalizer localizer, DeviceHubService deviceHubService)
            : base(applicationContext, tokenService, provider, localizer) 
        {
            this.deviceHubService = deviceHubService;
            protector = provider.CreateProtector("DeviceService");
        }

        public async Task<DeviceResponse> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);
            var user = await applicationContext.Devices.FindAsync(identity.Id);
            if (user == null) throw new Exception(localizer["Login failed. The user is not an device."]);

            JwtSecurityToken token = tokenService.CreateJWTToken(identity);
            string encodedToken = tokenService.EncodeJWTToken(token);

            return new DeviceResponse(user.State, user.IsTurnedOn, encodedToken, token.ValidTo);
        }

        public async Task DeleteAsync(Guid deviceId)
        {
            Device device = await applicationContext.Devices.Include(d => d.UserIdentity).FirstOrDefaultAsync(d => d.Id == deviceId);
            UserIdentity identity = device.UserIdentity;

            if (identity == null || device == null) throw new Exception(localizer["Cannot delete this device."]);

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

            if (device == null) throw new Exception(localizer["Device with this identifier doesn`t exist."]);
            return device;
        }

        public async Task ResetAsync(Guid identityId, string newPassword)
        {
            var identity = await applicationContext.UserIdentities.FindAsync(identityId);
            if (identity == null)
            {
                throw new Exception(localizer["The user with such id was not found."]);
            }

            var smartDevice = await applicationContext.Devices.FindAsync(identity.Id);
            if (smartDevice == null)
            {
                throw new Exception(localizer["The user with such id is not a smart device."]);
            }

            string login = identity.Login;
            await DeleteAsync(identity.Id);
            await RegisterAsync(new Device(login, newPassword));
        }

        public async Task UpdateConfigurationAsync(
            Guid deviceId, 
            DeviceUpdateRequest request)
        {
            Device device = await GetOneAsync(deviceId);

            device.IsTurnedOn = request.IsTurnedOn;
            device.State = request.DeviceState;
            if (request.ProcedureId != null) device.Procedure = 
                    await applicationContext.Procedures
                    .FindAsync(request.ProcedureId);

            await applicationContext.SaveChangesAsync();

            await deviceHubService.SendUpdateMessageAsync(deviceId);
        }

        public async Task ActivateAsync(DeviceActivateRequest activateRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                Login = activateRequest.SerialNumber,
                Password = activateRequest.DefaultPassword
            };
            Device device = await GetDeviceByLoginPassword(loginRequest);
            if (device.State != DeviceState.Inactive)
            {
                throw new Exception(localizer["The smart device cannot be activated."]);
            }

            bool smartDeviceReceivedMessage = await deviceHubService.TrySendActivateMessageAsync(
                device.Id, activateRequest.NewPassword);
            if (!smartDeviceReceivedMessage)
            {
                throw new Exception(localizer["The smart device is not connected to the service."]);
            }

            device.Activate(protector.Protect(activateRequest.NewPassword));
            await applicationContext.SaveChangesAsync();
        }

        private async Task<Device> GetDeviceByLoginPassword(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest);

            var smartDevice = await applicationContext.Devices.FindAsync(identity.Id);
            if (smartDevice == null)
            {
                throw new Exception(localizer["The user with such id is not a smart device."]);
            }
            return smartDevice;
        }
    }
}
