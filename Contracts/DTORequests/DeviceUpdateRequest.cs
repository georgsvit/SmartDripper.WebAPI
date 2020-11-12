using SmartDripper.WebAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class DeviceUpdateRequest
    {
        public DeviceState DeviceState { get; set; }
        public Guid ProcedureId { get; set; }
        public bool IsTurnedOn { get; set; }
    }
}
