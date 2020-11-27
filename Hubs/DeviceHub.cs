using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.DEVICE)]
    public class DeviceHub : Hub
    {
        private static readonly HashSet<string> ConnectedDevicesIds = new HashSet<string>();

        public override Task OnConnectedAsync()
        {
            ConnectedDevicesIds.Add(Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedDevicesIds.Remove(Context.User.Identity.Name);
            return base.OnDisconnectedAsync(exception);
        }

        public static bool IsDeviceConnected(string id) => ConnectedDevicesIds.Contains(id);
    }
}
