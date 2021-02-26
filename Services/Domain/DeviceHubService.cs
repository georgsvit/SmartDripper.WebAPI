using Microsoft.AspNetCore.SignalR;
using SmartDripper.WebAPI.Hubs;
using System;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class DeviceHubService
    {
        private const string UPDATE_COMAND = "Update";
        private const string ACTIVATE_COMMAND = "Activate";

        private readonly IHubContext<DeviceHub> deviceHub;

        public DeviceHubService(IHubContext<DeviceHub> deviceHub)
        {
            this.deviceHub = deviceHub;
        }

        public async Task SendUpdateMessageAsync(Guid id)
        {
            var device = deviceHub.Clients.User(id.ToString());
            await device.SendAsync(UPDATE_COMAND, "Text");
        }

        public async Task<bool> TrySendActivateMessageAsync(Guid id, string newPassword)
        {
            string recipientId = id.ToString();
            if (DeviceHub.IsDeviceConnected(recipientId))
            {
                var user = deviceHub.Clients.User(recipientId);
                await user.SendAsync(ACTIVATE_COMMAND, newPassword);
                return true;
            }
            return false;
        }
    }
}
