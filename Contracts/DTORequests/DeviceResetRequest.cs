using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class DeviceResetRequest
    {
        public string NewPassword { get; set; }
    }
}
