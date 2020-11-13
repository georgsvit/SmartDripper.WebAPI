using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Contracts.DTORequests
{
    public class ProcedureRequest
    {
        public Guid? NurseId { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
