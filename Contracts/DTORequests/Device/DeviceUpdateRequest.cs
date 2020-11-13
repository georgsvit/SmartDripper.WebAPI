using SmartDripper.WebAPI.Models.Users;
using System;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class DeviceUpdateRequest
    {
        public DeviceState DeviceState { get; set; }
        public Guid ProcedureId { get; set; }
        public bool IsTurnedOn { get; set; }
    }
}
