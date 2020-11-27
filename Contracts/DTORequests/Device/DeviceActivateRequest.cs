using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests.Device
{
    public class DeviceActivateRequest
    {
        public string SerialNumber { get; set; }
        public string DefaultPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
