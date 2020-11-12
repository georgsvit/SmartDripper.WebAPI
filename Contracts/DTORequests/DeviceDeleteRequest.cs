using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class DeviceDeleteRequest
    {
        public Guid deviceId { get; set; }
        public Guid identityId { get; set; }
    }
}
